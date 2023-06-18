using Wiring.Data;
using Wiring.Repositories;

namespace Wiring.Services
{
    public class ShassiService : IShassiService
    {
        private readonly IHarnessRepository _harnessRepository;
        private readonly IHarnessWiresRepository _wiresRepository;

        public ShassiService(IHarnessRepository harnessRepository, IHarnessWiresRepository wiresRepository)
        {
            _harnessRepository = harnessRepository;
            _wiresRepository = wiresRepository;
        }

        public async Task<IEnumerable<ShassiResponse>> GenerateAndValidateShassi()
        {
            var shassi = await GenerateShassi();
            return ValidateShassi(shassi);
        }

        public List<ShassiResponse> ValidateShassi(IEnumerable<Harness> shassi)
        {
            List<ShassiResponse> shassiResponse = new List<ShassiResponse>();
            
            for(int i = 0; i < shassi.Count() - 1; i++)
            {
                for (int j = i + 1; j < shassi.Count(); j++)
                { 
                    var harness1 = shassi.ElementAt(i);
                    var harness2 = shassi.ElementAt(j);
                    shassiResponse.Add(ValidateHarnesses(harness1, harness2));
                }
            }

            return shassiResponse;
        }

        private ShassiResponse ValidateHarnesses(Harness harness1, Harness harness2)
        {
            var occupiedHousings = new HashSet<string>();
            
            var housingWires = string.Join(", ", harness1.Wires.Select(x => x.Housing1 + ", " + x.Housing2));
            housingWires += Environment.NewLine;
            housingWires += string.Join(", ", harness2.Wires.Select(x => x.Housing1 + ", " + x.Housing2));

            ShassiResponse validatedComplect = new ShassiResponse
            {
                Harness1 = harness1,
                Harness2 = harness2,
                Housing = housingWires,
                IsValid = true
            };

            foreach (var wire in harness1.Wires)
            {
                if(!ValidateHarnessWires(occupiedHousings, wire))
                {
                    validatedComplect.IsValid = false;
                    break;
                }
            }

            if(validatedComplect.IsValid)
            {
                foreach (var wire in harness2.Wires)
                {
                    if (!ValidateHarnessWires(occupiedHousings, wire))
                    {
                        validatedComplect.IsValid = false;
                        break;
                    }
                }
            }

            return validatedComplect;
        }

        private bool ValidateHarnessWires(HashSet<string> occupiedHousings, HarnessWireDTO wire)
        {
            if (!string.IsNullOrEmpty(wire.Housing1))
            {
                string port = "";
                if(wire.Housing1.Contains(':'))
                {
                    string housing = wire.Housing1.Trim();
                    port = housing.Substring(0, housing.IndexOf(':'));
                }
                
                if (occupiedHousings.Contains(port))
                {
                    return false;
                }
                else if (occupiedHousings.Contains(wire.Housing1))
                {
                    return false;
                }
                else
                {
                    occupiedHousings.Add(wire.Housing1);
                }
            }

            if (!string.IsNullOrEmpty(wire.Housing2))
            {
                string port = "";
                if (wire.Housing2.Contains(':'))
                {
                    string housing = wire.Housing2.Trim();
                    port = housing.Substring(0, housing.IndexOf(':'));
                }

                if (occupiedHousings.Contains(port))
                {
                    return false;
                }
                else if (occupiedHousings.Contains(wire.Housing2))
                {
                    return false;
                }
                else
                {
                    occupiedHousings.Add(wire.Housing2);
                }
            }

            return true;
        }

        private async Task<IEnumerable<Harness>> GenerateShassi()
        {
            Random random = new Random();
            var harnessCount = random.Next(3, 5);

            IEnumerable<HarnessDTO> harnessesDB = await _harnessRepository.GetHarnesses();
            List<Harness> harnessList = await ConvertToHarnessList(harnessesDB);

            while (harnessList.Count > harnessCount)
            {
                var randomIndex = random.Next(0, harnessList.Count);
                harnessList.RemoveAt(randomIndex);
            }

            return harnessList;
        }

        private async Task<List<Harness>> ConvertToHarnessList(IEnumerable<HarnessDTO> harnessesDB)
        {
            List<Harness> harnessList = new List<Harness>();

            foreach (var harnessDB in harnessesDB)
            {
                IEnumerable<HarnessWireDTO> wiresDB = await _wiresRepository.GetWires(harnessDB.Id);
                var wires = wiresDB.ToList();

                Harness harness = new Harness
                {
                    Id = harnessDB.Id,
                    HarnessTitle = harnessDB.Harness,
                    HarnessVersion = harnessDB.HarnessVersion,
                    Drawing = harnessDB.Drawing,
                    DrawingVersion = harnessDB.DrawingVersion,
                    Wires = wires
                };

                harnessList.Add(harness);
            }

            return harnessList;
        }
    }
}

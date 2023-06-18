using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<Harness>> GenerateShassi()
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
                List<HarnessWire> wires = ConvertToWireList(wiresDB);

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

        private List<HarnessWire> ConvertToWireList(IEnumerable<HarnessWireDTO> wiresDB)
        {
            List<HarnessWire> wires = new List<HarnessWire>();
         
            foreach(var wireDB in wiresDB)
            {
                (string? housing1Port, string? housing1Pin) = GetHousingPortAndPin(wireDB.Housing1);
                (string? housing2Port, string? housing2Pin) = GetHousingPortAndPin(wireDB.Housing2);

                HarnessWire wire = new HarnessWire
                {
                    Id = wireDB.Id,
                    HarnessId = wireDB.HarnessId,
                    Length = wireDB.Length,
                    Color = wireDB.Color,
                    Housing1Port = housing1Port,
                    Housing1Pin = housing1Pin,
                    Housing2Port = housing2Port,
                    Housing2Pin = housing2Pin
                };

                wires.Add(wire);
            }

            return wires;
        }

        private (string?, string?) GetHousingPortAndPin(string? housing)
        {
            string? housingPort = null;
            string? housingPin = null;

            if (!string.IsNullOrEmpty(housing))
            {
                string[] HousingValues = housing.Split(":");

                if (HousingValues.Length == 1)
                {
                    housingPort = HousingValues[0];
                }
                else
                {
                    housingPort = HousingValues[0];
                    housingPin = HousingValues[1];
                }
            }

            return (housingPort, housingPin);
        }
    }
}

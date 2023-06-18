using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiring.Data;

namespace Wiring.Repositories;

public interface IHarnessRepository
{
    Task<IEnumerable<HarnessDTO>> GetHarnesses();

}

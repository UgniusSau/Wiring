using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiring.Data;

namespace Wiring.Repositories;

public interface IHarnessWiresRepository
{
    Task<IEnumerable<HarnessWireDTO>> GetWires(int id);
}

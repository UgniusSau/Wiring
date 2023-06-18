using Wiring.Data;

namespace Wiring.Repositories;

public interface IHarnessWiresRepository
{
    Task<IEnumerable<HarnessWireDTO>> GetWires(int id);
}

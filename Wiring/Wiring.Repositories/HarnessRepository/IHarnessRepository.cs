using Wiring.Data;

namespace Wiring.Repositories;

public interface IHarnessRepository
{
    Task<IEnumerable<HarnessDTO>> GetHarnesses();
}

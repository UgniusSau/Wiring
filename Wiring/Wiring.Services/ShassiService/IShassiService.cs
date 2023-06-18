using Wiring.Data;

namespace Wiring.Services;

public interface IShassiService
{
    Task<IEnumerable<ShassiResponse>> GenerateAndValidateShassi();
}

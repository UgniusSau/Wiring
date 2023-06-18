using Microsoft.EntityFrameworkCore;
using Wiring.Data;

namespace Wiring.Repositories;

public class HarnessRepository : IHarnessRepository
{
    private readonly WiringContext _context;

    public HarnessRepository(WiringContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<HarnessDTO>> GetHarnesses()
    {
        var query = @"
                    SELECT 
                        ID,
                        Harness,
                        Harness_version AS HarnessVersion,
                        Drawing,
                        Drawing_version AS DrawingVersion
                    FROM 
                        Harness_drawing";

        var harnesses = await _context.Set<HarnessDTO>().FromSqlRaw(query).ToListAsync();
        return harnesses;
    }
}

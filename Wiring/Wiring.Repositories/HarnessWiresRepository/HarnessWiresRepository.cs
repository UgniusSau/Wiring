using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Wiring.Data;

namespace Wiring.Repositories
{
    public class HarnessWiresRepository : IHarnessWiresRepository
    {
        private readonly WiringContext _context;

        public HarnessWiresRepository(WiringContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HarnessWireDTO>> GetWires(int id)
        {
            var query = "SELECT ID, Harness_ID AS HarnessId, Length, Color, Housing_1 AS Housing1, Housing_2 AS Housing2 FROM Harness_wires WHERE Harness_ID = @id";
            var harnessWires = await _context.Set<HarnessWireDTO>()
                .FromSqlRaw(query, new SqliteParameter("@id", id))
                .ToListAsync();

            return harnessWires;
        }
    }
}

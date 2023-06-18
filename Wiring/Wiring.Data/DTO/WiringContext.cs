using Microsoft.EntityFrameworkCore;

namespace Wiring.Data;

public partial class WiringContext : DbContext
{
    public WiringContext()
    {
    }

    public WiringContext(DbContextOptions<WiringContext> options)
        : base(options)
    {
    }

    public virtual DbSet<HarnessDTO> HarnessDrawings { get; set; }

    public virtual DbSet<HarnessWireDTO> HarnessWires { get; set; }
}

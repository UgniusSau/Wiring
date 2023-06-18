using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Wiring.Data.DTO;

public partial class WiringContext : DbContext
{
    public WiringContext()
    {
    }

    public WiringContext(DbContextOptions<WiringContext> options)
        : base(options)
    {
    }

    public virtual DbSet<HarnessDrawing> HarnessDrawings { get; set; }

    public virtual DbSet<HarnessWire> HarnessWires { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=Wiring.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HarnessDrawing>(entity =>
        {
            entity.ToTable("Harness_drawing");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Drawing).HasColumnType("Varchar(30)");
            entity.Property(e => e.DrawingVersion)
                .HasColumnType("Varchar(30)")
                .HasColumnName("Drawing_version");
            entity.Property(e => e.Harness).HasColumnType("Varchar(30)");
            entity.Property(e => e.HarnessVersion)
                .HasColumnType("Varchar(30)")
                .HasColumnName("Harness_version");
        });

        modelBuilder.Entity<HarnessWire>(entity =>
        {
            entity.ToTable("Harness_wires");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Color).HasColumnType("Varchar(30)");
            entity.Property(e => e.HarnessId).HasColumnName("Harness_ID");
            entity.Property(e => e.Housing1)
                .HasColumnType("Varchar(30)")
                .HasColumnName("Housing_1");
            entity.Property(e => e.Housing2)
                .HasColumnType("Varchar(30)")
                .HasColumnName("Housing_2");
            entity.Property(e => e.Length).HasColumnType("float");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

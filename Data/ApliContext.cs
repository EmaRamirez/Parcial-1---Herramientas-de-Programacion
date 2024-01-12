using Microsoft.EntityFrameworkCore;
using Parcial1.Models;

namespace Parcial1.Data;

public class ApliContext : DbContext
{
    public ApliContext(DbContextOptions<ApliContext> options) : base(options)
    {

    }

    public DbSet<Alumno> Alumnos { get; set; }

    public DbSet<Carrera> Carreras { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>()
        .HasOne(x => x.carrera)
        .WithMany(x => x.Alumnos)
        .HasForeignKey(x => x.CarreraId);

    }
}
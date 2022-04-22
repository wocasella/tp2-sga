using GestionAcademica.Domain;
using Microsoft.EntityFrameworkCore;

namespace GestionAcademica.Services
{
    public class GestionAcademicaContext : DbContext
    {
        public DbSet<Especialidad> Especialidades => Set<Especialidad>();

        public GestionAcademicaContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Especialidad>(x =>
                x.Property(p => p.Nombre).HasConversion(p => p.Value, p => NombreEspecialidad.Create(p).Value));
        }
    }
}

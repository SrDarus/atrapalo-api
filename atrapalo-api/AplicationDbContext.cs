using atrapalo_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace atrapalo_api
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Persona> Persona { get; set; }
        public DbSet<Vehiculo> Vehiculo { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<Tipo> Tipo { get; set; }
        public DbSet<Robo> Robo { get; set; }
        public DbSet<Ubicacion> Ubicacion { get; set; }
    }
}

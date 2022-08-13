using atrapalo_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace atrapalo_api
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Vehiculo> Vehiculo { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Color> Color { get; set; }
    }
}

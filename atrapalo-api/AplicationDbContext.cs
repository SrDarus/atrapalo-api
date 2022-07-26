using Microsoft.EntityFrameworkCore;

namespace atrapalo_api
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}

using Markel.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Markel.Models
{
    public class MarkelDbContext(DbContextOptions<MarkelDbContext> options) : DbContext(options)
    {
        public DbSet<Claim> Claims { get; set; }
        public DbSet<ClaimType> ClaimTypes { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
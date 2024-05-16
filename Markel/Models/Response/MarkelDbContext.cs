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

            // modelBuilder.Entity<Claim>()
            //     .Property(c => c.Closed)
            //     .HasColumnType("bit");

            // modelBuilder.Entity<Claim>()
            //     .Property(c => c.IncurredLoss)
            //     .HasColumnType("decimal(15,2)");

            // modelBuilder.Entity<Company>()
            //     .Property(c => c.Active)
            //     .HasColumnType("bit");
        }
    }
}
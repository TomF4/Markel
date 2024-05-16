using Microsoft.EntityFrameworkCore;

namespace Markel.Models.Domain
{
    public class MarkelDbContext(DbContextOptions<MarkelDbContext> options) : DbContext(options)
    {
        public DbSet<Claim> Claims { get; set; }
        public DbSet<ClaimType> ClaimTypes { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Claim>(entity =>
            {
                entity.HasKey(e => e.UCR); 
                entity.Property(e => e.UCR).HasMaxLength(20);
                entity.Property(e => e.CompanyId);
                entity.Property(e => e.ClaimDate).HasColumnType("datetime");
                entity.Property(e => e.LossDate).HasColumnType("datetime");
                entity.Property(e => e.AssuredName).HasColumnName("[Assured Name]").HasMaxLength(100); // unsure if the [ ] was literal?
                entity.Property(e => e.IncurredLoss).HasColumnName("[Incurred Loss]").HasColumnType("decimal(15,2)");
                entity.Property(e => e.Closed);
            });

            modelBuilder.Entity<ClaimType>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(200);
                entity.Property(e => e.Address1).HasMaxLength(100);
                entity.Property(e => e.Address2).HasMaxLength(100);
                entity.Property(e => e.Address3).HasMaxLength(100);
                entity.Property(e => e.Postcode).HasMaxLength(20);
                entity.Property(e => e.Country).HasMaxLength(50);
                entity.Property(e => e.Active);
                entity.Property(e => e.InsuranceEndDate).HasColumnType("datetime");
            });
        }
    }
}
using HomeWork21.Data.Entities;
using HomeWork21.Data.EntitiesConfigure;
using Microsoft.EntityFrameworkCore;

namespace HomeWork21.Data
{
    internal class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) 
            : base(options) 
        { }
        
        public DbSet<BreedEntity> Breeds { get; set; } = null!;
        public DbSet<CategoryEntity> Categories { get; set; } = null!;
        public DbSet<LocationEntity> Locations { get; set; } = null!;
        public DbSet<PetEntity> Pets { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryEntityConfigure());
            modelBuilder.ApplyConfiguration(new BreedEntityConfigure());
            modelBuilder.ApplyConfiguration(new LocationEntityConfigure());
            modelBuilder.ApplyConfiguration(new PetEntityConfiguration());
            modelBuilder.UseHiLo();
        }
    }
}

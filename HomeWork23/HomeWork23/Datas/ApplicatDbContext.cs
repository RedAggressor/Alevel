using HomeWork23.Datas.Entities;
using HomeWork23.Datas.EntityConfigure;
using Microsoft.EntityFrameworkCore;

namespace HomeWork23.Datas
{
    internal class ApplicatDbContext : DbContext
    {
        public ApplicatDbContext(DbContextOptions<ApplicatDbContext> option) : base(option)
        {}

        public DbSet<BreedEntity> Breeds { get; set; } = null!;
        public DbSet<CategoryEntity> Categories { get; set; } = null!;
        public DbSet<LocationEntity> Locations { get; set; } = null!;
        public DbSet<PetEntity> Pets { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PetEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new LocationEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BreedEntityConffiguration());
            modelBuilder.UseHiLo();
        }
    }
}

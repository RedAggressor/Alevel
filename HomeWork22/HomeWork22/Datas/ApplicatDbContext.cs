using HomeWork22.Datas.Entities;
using HomeWork22.Datas.EntitiesConfigurations;
using Microsoft.EntityFrameworkCore;

namespace HomeWork22.Datas
{
    internal class ApplicatDbContext : DbContext
    {
        public ApplicatDbContext(DbContextOptions<ApplicatDbContext> options) 
            : base(options)
        {}

        public DbSet<CostumerEntity> Costumers { get; set; } = null!;
        public DbSet<OrderEntity> Orders { get; set; } = null!;
        public DbSet<OrderItemEntity> OrderItems { get; set; } = null!;
        public DbSet<ProductEntity> Products { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CostumerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrderEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemEntityConguration());
            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
        }
    }
}

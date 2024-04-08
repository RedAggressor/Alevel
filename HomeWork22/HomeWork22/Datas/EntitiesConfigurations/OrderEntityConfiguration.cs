using HomeWork22.Datas.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeWork22.Datas.EntitiesConfigurations
{
    internal class OrderEntityConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder
                .HasOne(o => o.Costumer)
                .WithMany(m => m.Orders)
                .HasForeignKey(o => o.CostumerId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}

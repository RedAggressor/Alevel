using HomeWork22.Datas.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeWork22.Datas.EntitiesConfigurations
{
    internal class OrderItemEntityConguration : IEntityTypeConfiguration<OrderItemEntity>
    {
        public void Configure(EntityTypeBuilder<OrderItemEntity> builder)
        {
            builder.HasKey(x=>x.Id);

            builder
                .Property(x => x.Count)
                .IsRequired();

            builder
                .HasOne(x => x.Order)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(x=>x.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(x=>x.Product)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(x=>x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

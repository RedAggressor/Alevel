using HomeWork22.Datas.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeWork22.Datas.EntitiesConfigurations
{
    internal class CostumerEntityConfiguration : IEntityTypeConfiguration<CostumerEntity>
    {
        public void Configure(EntityTypeBuilder<CostumerEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(p => p.FirstName)
                .HasMaxLength(50);

            builder
                .Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}

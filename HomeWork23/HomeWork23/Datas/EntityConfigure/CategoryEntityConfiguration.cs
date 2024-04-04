using HomeWork23.Datas.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeWork23.Datas.EntityConfigure
{
    internal class CategoryEntityConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder
                .HasKey(x => x.Id);
                

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasColumnName("category_name");
        }
    }
}

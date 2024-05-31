using HomeWork21.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeWork21.Data.EntitiesConfigure
{
    internal class CategoryEntityConfigure : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.HasKey(k => k.Id);
            builder
                .Property(p => p.CategoryName)
                .IsRequired()
                .HasColumnName("Category_Name");

        }
    }
}

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
            builder.Property(p => p.CategoryName).IsRequired().HasColumnName("category_name");
            builder.Property(p => p.PetId).IsRequired();
            builder.Property(p => p.BreedId).IsRequired();

            builder
                .HasOne(o=>o.Pet)
                .WithMany(m=>m.Category)
                .HasForeignKey(o => o.PetId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder
                .HasOne(o => o.Breed)
                .WithMany(m => m.Category)
                .HasForeignKey(k => k.BreedId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}

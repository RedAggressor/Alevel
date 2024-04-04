using HomeWork23.Datas.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeWork23.Datas.EntityConfigure
{
    internal class BreedEntityConffiguration : IEntityTypeConfiguration<BreedEntity>
    {
        public void Configure(EntityTypeBuilder<BreedEntity> builder)
        {
            builder
                .HasKey(x => x.Id);
                

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasColumnName("breed_name");

            builder.Property(x => x.CategoryId).HasColumnName("category_id");

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Breeds)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

using HomeWork23.Datas.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeWork23.Datas.EntityConfigure
{
    internal class PetEntityConfiguration : IEntityTypeConfiguration<PetEntity>
    {
        public void Configure(EntityTypeBuilder<PetEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasColumnName("name");

            builder
                .Property(x => x.Age)
                .IsRequired()
                .HasColumnName("age");

            builder
                .Property(x => x.Description)
                .HasColumnName("discription");

            builder
                .Property(x => x.ImageUrl)
                .HasColumnName("image_url");

            builder.Property(x => x.BreedId).HasColumnName("breed_id");
            builder
                .HasOne(x=>x.Breed)
                .WithMany(x=>x.Pets)
                .HasForeignKey(x=>x.BreedId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.CategoryId).HasColumnName("category_id");
            builder
                .HasOne(x => x.Category)
                .WithMany(x => x.Pets)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.LocationId).HasColumnName("location_id");
            builder
                .HasOne(x => x.Location)
                .WithMany(x => x.Pets)
                .HasForeignKey(x => x.LocationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

using HomeWork21.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeWork21.Data.EntitiesConfigure
{
    internal class PetEntityConfiguration : IEntityTypeConfiguration<PetEntity>
    {
        public void Configure(EntityTypeBuilder<PetEntity> builder)
        {
            builder.ToTable("Pet", "dbo");

            builder.HasKey(k => k.Id);
            builder.Property(p=>p.Name).IsRequired();
            builder.Property(p => p.Age).IsRequired();
            builder.Property(p => p.ImageUrl).HasColumnName("Image_Url");
            builder.Property(p => p.Description);
            builder.Property(p => p.CategoryId).IsRequired().HasColumnName("Category_Id");
            builder.Property(p => p.BreedId).IsRequired().HasColumnName("Breed_Id");
            builder.Property(p => p.LocationId).IsRequired().HasColumnName("Location_Id");

            builder
                .HasOne(o => o.Category)
                .WithMany(m => m.Pet)
                .HasForeignKey(o => o.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(o => o.Breed)
                .WithMany(m => m.Pet)
                .HasForeignKey(o => o.BreedId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder
                .HasOne(o => o.Location)
                .WithMany(m => m.Pet)
                .HasForeignKey(o => o.LocationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

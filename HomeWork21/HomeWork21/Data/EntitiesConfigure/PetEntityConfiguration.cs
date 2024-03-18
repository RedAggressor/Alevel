using HomeWork21.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeWork21.Data.EntitiesConfigure
{
    internal class PetEntityConfiguration : IEntityTypeConfiguration<PetEntity>
    {
        public void Configure(EntityTypeBuilder<PetEntity> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p=>p.Name).IsRequired();
            builder.Property(p => p.Age).IsRequired();
            builder.Property(p => p.ImageUrl).HasColumnName("image_url");
            builder.Property(p => p.Description);               
        }
    }
}

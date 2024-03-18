using HomeWork21.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeWork21.Data.EntitiesConfigure
{
    internal class LocationEntityConfigure : IEntityTypeConfiguration<LocationEntity>
    {
        public void Configure(EntityTypeBuilder<LocationEntity> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p=>p.PetId).IsRequired();

            builder
                .Property(p => p.LocationName)
                .IsRequired()
                .HasColumnName("location_name");
                

            builder
                .HasOne(o => o.Pet)
                .WithMany(o => o.LocationName)
                .HasForeignKey(k => k.PetId)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}

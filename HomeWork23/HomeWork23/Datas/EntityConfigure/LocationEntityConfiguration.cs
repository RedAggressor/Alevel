using HomeWork23.Datas.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeWork23.Datas.EntityConfigure
{
    internal class LocationEntityConfiguration : IEntityTypeConfiguration<LocationEntity>
    {
        public void Configure(EntityTypeBuilder<LocationEntity> builder)
        {
            builder
                .HasKey(x => x.Id);
                

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasColumnName("location_name");
        }
    }
}

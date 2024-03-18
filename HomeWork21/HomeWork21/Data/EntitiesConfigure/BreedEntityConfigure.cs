﻿using HomeWork21.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeWork21.Data.EntitiesConfigure
{
    internal class BreedEntityConfigure : IEntityTypeConfiguration<BreedEntity>
    {
        public void Configure(EntityTypeBuilder<BreedEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.BreedName).IsRequired().HasColumnName("breed_name");
            builder.Property(p => p.PetId).IsRequired();

            builder
                .HasOne(o=>o.Pet)
                .WithMany(m => m.Breed)
                .HasForeignKey(o => o.PetId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

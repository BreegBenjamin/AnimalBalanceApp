using AnimalBalanceApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalBalanceApp.Infrastructure.Data.Configurations
{
    public class SpeciesConfiguration : IEntityTypeConfiguration<Species>
    {
        public void Configure(EntityTypeBuilder<Species> builder)
        {
            builder.HasKey(e => e.SpecieId)
                    .HasName("PK__Species__6B45E1D056028A67");

            builder.Property(e => e.SpaceForUnity)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Temperature)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.TypeSpecie)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.WaterForDay)
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}

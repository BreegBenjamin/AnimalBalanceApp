using AnimalBalanceApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalBalanceApp.Infrastructure.Data.Configurations
{
    public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.Property(e => e.Id).HasColumnName("AnimalID");

            builder.Property(e => e.AgeForSale)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.AnimalName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Price)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.SpecieId).HasColumnName("SpecieID");

            builder.HasOne(d => d.Specie)
                .WithMany(p => p.Animals)
                .HasForeignKey(d => d.SpecieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Animals__SpecieI__2F10007B");
        }
    }
}

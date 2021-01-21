using AnimalBalanceApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalBalanceApp.Infrastructure.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(e => e.ProductId).HasColumnName("ProductID");

            builder.Property(e => e.AnimalId).HasColumnName("AnimalID");

            builder.Property(e => e.ContainerName)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.ImageName)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.PriceKm)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PriceKM");

            builder.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.HasOne(d => d.Animal)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.AnimalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__Animal__31EC6D26");
        }
    }
}

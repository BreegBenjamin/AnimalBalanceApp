using AnimalBalanceApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalBalanceApp.Infrastructure.Data.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(e => e.ImageNum)
                   .HasName("PK__Images__4ACBE92FD085E2F9");

            builder.Property(e => e.ContainerImageName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.ImageName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.ImageType)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.PostDate).HasColumnType("datetime");

            builder.Property(e => e.PostId).HasColumnName("PostID");

            builder.HasOne(d => d.Post)
                .WithMany(p => p.Images)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Images__PostID__34C8D9D1");
        }
    }
}

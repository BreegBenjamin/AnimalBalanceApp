using AnimalBalanceApp.Core.Entitis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalBalanceApp.Infrastructure.Data.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Post");

            builder.Property(e => e.PostId).HasColumnName("PostID");

            builder.Property(e => e.Category)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.ContainerImagesName)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.DatePost).HasColumnType("datetime");

            builder.Property(e => e.PostDescription)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(e => e.UserId).HasColumnName("UserID");

            builder.HasOne(d => d.User)
                .WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Post__UserID__267ABA7A");
        }
    }
}

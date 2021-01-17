using AnimalBalanceApp.Core.Entitis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalBalanceApp.Infrastructure.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(e => e.CommentId).HasColumnName("CommentID");

            builder.Property(e => e.CommentDescription)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(e => e.PostDate).HasColumnType("datetime");

            builder.Property(e => e.PostId).HasColumnName("PostID");

            builder.Property(e => e.UserId).HasColumnName("UserID");

            builder.HasOne(d => d.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comments__PostID__29572725");

            builder.HasOne(d => d.User)
                .WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comments__UserID__2A4B4B5E");
        }
    }
}

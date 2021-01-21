using AnimalBalanceApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalBalanceApp.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.Id).HasColumnName("UserID");

            builder.Property(e => e.Birthdate).HasColumnType("datetime");

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.ImageName)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Telephone)
                .HasMaxLength(15)
                .IsUnicode(false);

            builder.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}

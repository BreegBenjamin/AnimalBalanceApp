using AnimalBalanceApp.Core.Entities;
using AnimalBalanceApp.Core.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalBalanceApp.Infrastructure.Data.Configurations
{
    public class SecurityConfiguration : IEntityTypeConfiguration<Security>
    {
        public void Configure(EntityTypeBuilder<Security> builder)
        {
            builder.Property(e => e.Id).HasColumnName("IdSecurity");

            builder.Property(e => e.SecurityUser)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.UserPassword)
               .IsRequired()
               .HasMaxLength(200)
               .IsUnicode(false);

            builder.Property(e => e.UserRol)
               .IsRequired()
               .HasMaxLength(15)
               .IsUnicode(false)
               .HasConversion( 
                x=> x.ToString(), 
                x=> (RoleType)Enum.Parse(typeof(RoleType),x));
        }
    }
}

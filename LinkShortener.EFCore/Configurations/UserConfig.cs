using LinkShortener.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.EFCore.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.IdUser);
            builder.Property(u => u.Name).HasMaxLength(50).HasColumnType("varchar").IsRequired();
            builder.Property(u => u.Lastname).HasMaxLength(50).HasColumnType("varchar").IsRequired();
            builder.Property(u => u.Email).HasMaxLength(50).HasColumnType("varchar").IsRequired();
            builder.Property(u => u.Username).HasMaxLength(50).HasColumnType("varchar").IsRequired();
            builder.Property(u => u.Password).HasMaxLength(512).IsRequired();
            builder.Property(u => u.CreationDate).HasColumnType("datetime2");
            builder.Property(u => u.ModificationDate).HasColumnType("datetime2");
        }
    }
}

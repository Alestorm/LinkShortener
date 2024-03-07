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
    public class LinkConfig : IEntityTypeConfiguration<Link>
    {
        public void Configure(EntityTypeBuilder<Link> builder)
        {
            builder.HasKey(l => l.IdLink);
            builder.Property(l => l.Url).HasMaxLength(2083).HasColumnType("nvarchar");
            builder.Property(l => l.ShortUrl).HasMaxLength(100).HasColumnType("nvarchar");
            builder.Property(l => l.Code).HasMaxLength(7).HasColumnType("varchar");
            builder.Property(l => l.CreationDate).HasColumnType("datetime2");
            builder.Property(l => l.ModificationDate).HasColumnType("datetime2");
        }
    }
}
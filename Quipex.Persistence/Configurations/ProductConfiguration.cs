using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quipex.Domain.Entities;

namespace Quipex.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<CompanyRecord>
{
    public void Configure(EntityTypeBuilder<CompanyRecord> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Name)
               .IsRequired()
               .HasMaxLength(100);
        builder.Property(r => r.StockTicker)
               .IsRequired()
               .HasMaxLength(100);
        builder.Property(r => r.Exchange)
               .IsRequired()
               .HasMaxLength(100);
        builder.Property(r => r.ISIN)
               .IsRequired()
               .HasMaxLength(12);
        builder.Property(r => r.Website)
               .HasMaxLength(100);

        builder.HasIndex(r => r.ISIN).IsUnique();
    }
}

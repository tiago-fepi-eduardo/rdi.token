using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Token.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Token.Infra.Data.Mappings
{
    public class TokenMap : IEntityTypeConfiguration<TokenEntity>
    {
        public void Configure(EntityTypeBuilder<TokenEntity> builder)
        {
            builder.ToTable("Token");

            builder.HasKey(c => c.Date);

            builder.Property(c => c.CardNumber)
                .IsRequired();

            builder.Property(c => c.Date)
                .IsRequired();

            builder.Property(c => c.CVV)
                .IsRequired();
        }
    }
}

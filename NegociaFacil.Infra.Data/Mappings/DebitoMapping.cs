using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NegociaFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegociaFacil.Infra.Data.Mappings
{
    public class DebitoMapping : IEntityTypeConfiguration<Debito>
    {
        public void Configure(EntityTypeBuilder<Debito> builder)
        {
            builder.Property(e => e.Valor)
                     .HasColumnType("decimal(18,4)")
                     .IsRequired();

            builder.ToTable("Debito");
        }
    }
}

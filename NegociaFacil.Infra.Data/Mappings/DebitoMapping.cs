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

            builder.Property(e => e.Observacao)
                 .HasColumnType("varchar(300)")
                 .HasMaxLength(300);

            builder.Property(e => e.DevedorId)
                .IsRequired();

            builder.Property(e => e.CredorId)
                .IsRequired();

            builder.ToTable("Debito");
        }
    }
}

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
    public class DevedorMapping : IEntityTypeConfiguration<Devedor>
    {
        public void Configure(EntityTypeBuilder<Devedor> builder)
        {
            builder.Property(e => e.Id)
                .HasDefaultValueSql("NEWID()");

            builder.Property(e => e.Nome)
                     .HasColumnType("varchar(100)")
                     .HasMaxLength(100)
                     .IsRequired();

            builder.Property(e => e.Documento)
                     .HasColumnType("varchar(14)")
                     .HasMaxLength(14)
                     .IsRequired();

            builder.ToTable("Devedor");
        }
    }
}

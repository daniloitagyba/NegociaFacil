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
    public class CredorMapping : IEntityTypeConfiguration<Credor>
    {
        public void Configure(EntityTypeBuilder<Credor> builder)
        {
            builder.Property(e => e.Nome)
                     .HasColumnType("varchar(100)")
                     .HasMaxLength(100)
                     .IsRequired();

            builder.ToTable("Credor");
        }
    }
}

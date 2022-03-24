﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NegociaFacil.Infra.Data.DBContext;

namespace NegociaFacil.Infra.Data.Migrations.Application
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220324175629_auto-increment-credor-devedor")]
    partial class autoincrementcredordevedor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NegociaFacil.Domain.Entities.Credor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Credor");
                });

            modelBuilder.Entity("NegociaFacil.Domain.Entities.Debito", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CredorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DevedorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Observacao")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,4)");

                    b.Property<DateTime>("Vencimento")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CredorId");

                    b.HasIndex("DevedorId");

                    b.ToTable("Debito");
                });

            modelBuilder.Entity("NegociaFacil.Domain.Entities.Devedor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("TipoDocumento")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Devedor");
                });

            modelBuilder.Entity("NegociaFacil.Domain.Entities.Debito", b =>
                {
                    b.HasOne("NegociaFacil.Domain.Entities.Credor", "Credor")
                        .WithMany()
                        .HasForeignKey("CredorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NegociaFacil.Domain.Entities.Devedor", "Devedor")
                        .WithMany()
                        .HasForeignKey("DevedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Credor");

                    b.Navigation("Devedor");
                });
#pragma warning restore 612, 618
        }
    }
}

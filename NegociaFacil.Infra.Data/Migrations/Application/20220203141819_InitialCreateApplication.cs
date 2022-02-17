using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NegociaFacil.Infra.Data.Migrations.Application
{
    public partial class InitialCreateApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Credor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Debito",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CredorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Vencimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Debito_Credor_CredorId",
                        column: x => x.CredorId,
                        principalTable: "Credor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Debito_CredorId",
                table: "Debito",
                column: "CredorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Debito");

            migrationBuilder.DropTable(
                name: "Credor");
        }
    }
}

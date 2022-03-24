using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NegociaFacil.Infra.Data.Migrations.Application
{
    public partial class novaspropsentidadescredordevedordebito : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DevedorId",
                table: "Debito",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "Debito",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cnpj",
                table: "Credor",
                type: "varchar(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Devedor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    TipoDocumento = table.Column<int>(type: "int", nullable: false),
                    Documento = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devedor", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Debito_DevedorId",
                table: "Debito",
                column: "DevedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Debito_Devedor_DevedorId",
                table: "Debito",
                column: "DevedorId",
                principalTable: "Devedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Debito_Devedor_DevedorId",
                table: "Debito");

            migrationBuilder.DropTable(
                name: "Devedor");

            migrationBuilder.DropIndex(
                name: "IX_Debito_DevedorId",
                table: "Debito");

            migrationBuilder.DropColumn(
                name: "DevedorId",
                table: "Debito");

            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "Debito");

            migrationBuilder.DropColumn(
                name: "Cnpj",
                table: "Credor");
        }
    }
}

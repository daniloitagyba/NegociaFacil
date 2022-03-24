using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NegociaFacil.Infra.Data.Migrations.Application
{
    public partial class credordevedorrequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Debito_Credor_CredorId",
                table: "Debito");

            migrationBuilder.DropForeignKey(
                name: "FK_Debito_Devedor_DevedorId",
                table: "Debito");

            migrationBuilder.AlterColumn<Guid>(
                name: "DevedorId",
                table: "Debito",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CredorId",
                table: "Debito",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Debito_Credor_CredorId",
                table: "Debito",
                column: "CredorId",
                principalTable: "Credor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Debito_Devedor_DevedorId",
                table: "Debito",
                column: "DevedorId",
                principalTable: "Devedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Debito_Credor_CredorId",
                table: "Debito");

            migrationBuilder.DropForeignKey(
                name: "FK_Debito_Devedor_DevedorId",
                table: "Debito");

            migrationBuilder.AlterColumn<Guid>(
                name: "DevedorId",
                table: "Debito",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CredorId",
                table: "Debito",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Debito_Credor_CredorId",
                table: "Debito",
                column: "CredorId",
                principalTable: "Credor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Debito_Devedor_DevedorId",
                table: "Debito",
                column: "DevedorId",
                principalTable: "Devedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

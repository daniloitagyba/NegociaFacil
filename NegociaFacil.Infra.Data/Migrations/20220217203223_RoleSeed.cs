using Microsoft.EntityFrameworkCore.Migrations;

namespace NegociaFacil.Infra.Data.Migrations
{
    public partial class RoleSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ec7780b4-5ec3-4b96-8279-f15dcf503c24", "8c3594d2-dcf2-4a19-a2e2-ca82e2072457", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ca388ab5-e1b0-4c84-80e8-2fe6c51bd309", "4aabf662-9223-478b-b617-b4f6632d6b21", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca388ab5-e1b0-4c84-80e8-2fe6c51bd309");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec7780b4-5ec3-4b96-8279-f15dcf503c24");
        }
    }
}

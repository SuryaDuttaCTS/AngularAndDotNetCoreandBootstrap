using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngularApp1.Server.Migrations.authDb
{
    /// <inheritdoc />
    public partial class Useridentity2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "231e536e-c8d7-45a4-bd59-ddadbd69c232",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e35f69a1-fe3d-4196-9cbb-fc7d5039e537", "2a9a030a-b89c-41d4-ab33-f5f47586f4c6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "231e536e-c8d7-45a4-bd59-ddadbd69c232",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "662161e6-136c-4beb-beb8-caeebe7f4ba5", "e8befb99-4b0b-4189-883f-d75f840dfc5d" });
        }
    }
}

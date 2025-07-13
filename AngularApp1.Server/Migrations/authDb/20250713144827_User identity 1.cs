using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngularApp1.Server.Migrations.authDb
{
    /// <inheritdoc />
    public partial class Useridentity1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "231e536e-c8d7-45a4-bd59-ddadbd69c232",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "662161e6-136c-4beb-beb8-caeebe7f4ba5", "AQAAAAEAACcQAAAAEG0bbVbsptSgCdEcPOnkHuAkMZyfukDEvwOxLZbYq5E7wnQfEl08B4zqfh6UO5ZYqA==", "e8befb99-4b0b-4189-883f-d75f840dfc5d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "231e536e-c8d7-45a4-bd59-ddadbd69c232",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6033cc24-790a-4259-95f7-67099af1ebe2", "AQAAAAIAAYagAAAAEFp3eUwuDzNK+vWYOM+n6VPgPGBrRjXNIm9+79qkOrzkp3cl0OiPKZyEFlH2Xks07A==", "a1694ec6-0e8a-4770-b65d-4db7ebcd270b" });
        }
    }
}

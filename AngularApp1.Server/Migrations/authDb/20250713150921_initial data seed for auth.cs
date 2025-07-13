using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngularApp1.Server.Migrations.authDb
{
    /// <inheritdoc />
    public partial class initialdataseedforauth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edc267ec-d43c-4e3b-8108-a1a1f819906d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d627c58e-4ede-4bed-9d14-ce5f3485df9d", "2c76eac4-655e-4fd5-81d4-4f59c2f353e5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edc267ec-d43c-4e3b-8108-a1a1f819906d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "348ba73e-d2f6-40ad-8161-3c29150b9591", "00d6c4c0-c296-4140-b669-247f8da021a8" });
        }
    }
}

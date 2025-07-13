using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngularApp1.Server.Migrations.authDb
{
    /// <inheritdoc />
    public partial class Useridentity4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edc267ec-d43c-4e3b-8108-a1a1f819906d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "348ba73e-d2f6-40ad-8161-3c29150b9591", "AQAAAAEAACcQAAAAEKCdTdvRwAGyJrZ45JcQJkqD13Gb0RzJ1fVRmpmXCrfCgFLx3T4Y9AwcJqP8k2F3Mg==", "00d6c4c0-c296-4140-b669-247f8da021a8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edc267ec-d43c-4e3b-8108-a1a1f819906d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31a062d4-a18d-4493-b957-9859590099fe", "AQAAAAIAAYagAAAAEEj7qedrx6nGtYZap8xMpJrCIpKkNdzAtXTGKWG2kzfG64750eKV0JL7FY0Ks97ngQ==", "ea5d0ed5-fa37-4982-85c1-1114c69f9e15" });
        }
    }
}

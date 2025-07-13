using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AngularApp1.Server.Migrations.authDb
{
    /// <inheritdoc />
    public partial class Useridentity3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "54207340-c290-40e7-8474-aa0be169cc88", "231e536e-c8d7-45a4-bd59-ddadbd69c232" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "839bd3ff-184d-4dde-a6ec-14dc5b7c83d7", "231e536e-c8d7-45a4-bd59-ddadbd69c232" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54207340-c290-40e7-8474-aa0be169cc88");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "839bd3ff-184d-4dde-a6ec-14dc5b7c83d7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "231e536e-c8d7-45a4-bd59-ddadbd69c232");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "28d65a5b-a7db-4850-b380-83591f7d7531", "28d65a5b-a7db-4850-b380-83591f7d7531", "Reader", "READER" },
                    { "9740f16c-24a1-4224-a7be-1bb00b7c6892", "9740f16c-24a1-4224-a7be-1bb00b7c6892", "Writer", "WRITER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "edc267ec-d43c-4e3b-8108-a1a1f819906d", 0, "31a062d4-a18d-4493-b957-9859590099fe", "admin@codepulse.com", false, false, null, "ADMIN@CODEPULSE.COM", "ADMIN@CODEPULSE.COM", "AQAAAAIAAYagAAAAEEj7qedrx6nGtYZap8xMpJrCIpKkNdzAtXTGKWG2kzfG64750eKV0JL7FY0Ks97ngQ==", null, false, "ea5d0ed5-fa37-4982-85c1-1114c69f9e15", false, "admin@codepulse.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "28d65a5b-a7db-4850-b380-83591f7d7531", "edc267ec-d43c-4e3b-8108-a1a1f819906d" },
                    { "9740f16c-24a1-4224-a7be-1bb00b7c6892", "edc267ec-d43c-4e3b-8108-a1a1f819906d" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "28d65a5b-a7db-4850-b380-83591f7d7531", "edc267ec-d43c-4e3b-8108-a1a1f819906d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9740f16c-24a1-4224-a7be-1bb00b7c6892", "edc267ec-d43c-4e3b-8108-a1a1f819906d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28d65a5b-a7db-4850-b380-83591f7d7531");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9740f16c-24a1-4224-a7be-1bb00b7c6892");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edc267ec-d43c-4e3b-8108-a1a1f819906d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "54207340-c290-40e7-8474-aa0be169cc88", "54207340-c290-40e7-8474-aa0be169cc88", "Reader", "READER" },
                    { "839bd3ff-184d-4dde-a6ec-14dc5b7c83d7", "839bd3ff-184d-4dde-a6ec-14dc5b7c83d7", "Writer", "WRITER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "231e536e-c8d7-45a4-bd59-ddadbd69c232", 0, "e35f69a1-fe3d-4196-9cbb-fc7d5039e537", "suryajyotijpg@gmail.com", false, false, null, "SURYAJYOTIJPG@GMAIL.COM", "SURYAJYOTIJPG@GMAIL.COM", "AQAAAAEAACcQAAAAEG0bbVbsptSgCdEcPOnkHuAkMZyfukDEvwOxLZbYq5E7wnQfEl08B4zqfh6UO5ZYqA==", null, false, "2a9a030a-b89c-41d4-ab33-f5f47586f4c6", false, "suryajyotijpg@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "54207340-c290-40e7-8474-aa0be169cc88", "231e536e-c8d7-45a4-bd59-ddadbd69c232" },
                    { "839bd3ff-184d-4dde-a6ec-14dc5b7c83d7", "231e536e-c8d7-45a4-bd59-ddadbd69c232" }
                });
        }
    }
}

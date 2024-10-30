using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymFit.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "626f67f3-eaf3-4022-a61b-d865a026ff5d", null, "User", "USER" },
                    { "d28b7934-129b-4b04-bf84-3a972810b634", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a4727b42-0b17-42d3-a597-08f8a82a7402", 0, null, "a0d97444-4fec-4484-99fc-43f9d3ae87c1", "admin@gimfit.com", true, null, false, null, "ADMIN@GYMFIT.COM", "ADMIN@GYMFIT.COM", "AQAAAAIAAYagAAAAEDmPHKAqOUPsJoT3FFmhOiN6MLptJTvo2671uBTGLQw+ZGj0fkUQtF0lWlbGftLtxw==", null, false, "ee2f8bf7-ae0d-4e74-81af-3393072b6ed2", false, "admin@gimfit.com" },
                    { "abfcad06-e580-45d1-932b-1354b13130cd", 0, null, "9ff483fc-5b27-46d5-a0a1-dff1eb7cc622", "user@gimfit.com", true, null, false, null, "USER@GYMFIT.COM", "USER@GYMFIT.COM", "AQAAAAIAAYagAAAAED7H+RzVQwgQ/6rC4zojg+Urjl6MeSnZANAWxiCWXHY1PyCii5c9O2iFrGfczLOk+Q==", null, false, "164844cd-8f82-4d3b-984f-f8e266330b7b", false, "user@gimfit.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "d28b7934-129b-4b04-bf84-3a972810b634", "a4727b42-0b17-42d3-a597-08f8a82a7402" },
                    { "626f67f3-eaf3-4022-a61b-d865a026ff5d", "abfcad06-e580-45d1-932b-1354b13130cd" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d28b7934-129b-4b04-bf84-3a972810b634", "a4727b42-0b17-42d3-a597-08f8a82a7402" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "626f67f3-eaf3-4022-a61b-d865a026ff5d", "abfcad06-e580-45d1-932b-1354b13130cd" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "626f67f3-eaf3-4022-a61b-d865a026ff5d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d28b7934-129b-4b04-bf84-3a972810b634");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a4727b42-0b17-42d3-a597-08f8a82a7402");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "abfcad06-e580-45d1-932b-1354b13130cd");
        }
    }
}

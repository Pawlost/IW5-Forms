using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormsIW5.IdentityProvider.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddTestUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b1f70862-ba5c-45cd-9086-b99347db2ee8"),
                column: "ConcurrencyStamp",
                value: "4af0ce48-b9db-4d6e-b346-2da50d774add");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Active", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Subject", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("94aafab9-26f0-49ac-a5de-c98709057238"), 0, false, "fda5b000-6d2f-44b7-a4dd-5aac76e36d84", "xbalus03@vutbr.cz", false, false, null, "XBALUS03@VUTBR.CZ", "USER", "AQAAAAIAAYagAAAAEI14r3DlK6kMbyvIA1cf0/eFzpY8nbdDqwsTXeTEYgQZhG1XeS7hZLHrZWFmNnGCwQ==", null, false, null, "user", false, "User" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("94aafab9-26f0-49ac-a5de-c98709057238"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b1f70862-ba5c-45cd-9086-b99347db2ee8"),
                column: "ConcurrencyStamp",
                value: "60b06ed7-56a0-434c-9c5b-bd493a5e22d0");
        }
    }
}

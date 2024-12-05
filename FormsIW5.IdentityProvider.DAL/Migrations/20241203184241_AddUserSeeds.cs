using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormsIW5.IdentityProvider.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddUserSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Active", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Subject", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("b1f70862-ba5c-45cd-9086-b99347db2ee8"), 0, false, "5a65db3f-4b8f-4610-91de-9d1bfa846acf", "xbalus03@vutbr.cz", false, false, null, "XBALUS03@VUTBR.CZ", "ADMIN", "AQAAAAIAAYagAAAAEI14r3DlK6kMbyvIA1cf0/eFzpY8nbdDqwsTXeTEYgQZhG1XeS7hZLHrZWFmNnGCwQ==", null, false, null, "admin", false, "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b1f70862-ba5c-45cd-9086-b99347db2ee8"));
        }
    }
}

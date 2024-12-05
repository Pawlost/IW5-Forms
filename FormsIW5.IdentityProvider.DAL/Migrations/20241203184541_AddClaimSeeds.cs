using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormsIW5.IdentityProvider.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddClaimSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { -1, "role", "admin", new Guid("b1f70862-ba5c-45cd-9086-b99347db2ee8") });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b1f70862-ba5c-45cd-9086-b99347db2ee8"),
                column: "ConcurrencyStamp",
                value: "60b06ed7-56a0-434c-9c5b-bd493a5e22d0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b1f70862-ba5c-45cd-9086-b99347db2ee8"),
                column: "ConcurrencyStamp",
                value: "5a65db3f-4b8f-4610-91de-9d1bfa846acf");
        }
    }
}

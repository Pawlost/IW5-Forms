using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormsIW5.IdentityProvider.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddUserProfilePictureUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("94aafab9-26f0-49ac-a5de-c98709057238"),
                columns: new[] { "ConcurrencyStamp", "ProfilePictureUrl" },
                values: new object[] { "d98bb42a-70a4-421f-8ebb-952e5415e7b1", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b1f70862-ba5c-45cd-9086-b99347db2ee8"),
                columns: new[] { "ConcurrencyStamp", "ProfilePictureUrl" },
                values: new object[] { "a3eb614d-9321-483e-b2db-4ee6fbfb5e8d", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePictureUrl",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("94aafab9-26f0-49ac-a5de-c98709057238"),
                column: "ConcurrencyStamp",
                value: "fda5b000-6d2f-44b7-a4dd-5aac76e36d84");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b1f70862-ba5c-45cd-9086-b99347db2ee8"),
                column: "ConcurrencyStamp",
                value: "4af0ce48-b9db-4d6e-b346-2da50d774add");
        }
    }
}

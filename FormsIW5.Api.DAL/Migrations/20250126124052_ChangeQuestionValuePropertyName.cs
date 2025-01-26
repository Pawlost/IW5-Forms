using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormsIW5.Api.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeQuestionValuePropertyName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ToValue",
                table: "Questions",
                newName: "MinValue");

            migrationBuilder.RenameColumn(
                name: "FromValue",
                table: "Questions",
                newName: "MaxValue");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MinValue",
                table: "Questions",
                newName: "ToValue");

            migrationBuilder.RenameColumn(
                name: "MaxValue",
                table: "Questions",
                newName: "FromValue");
        }
    }
}

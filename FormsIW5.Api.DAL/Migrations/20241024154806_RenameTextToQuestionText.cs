using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormsIW5.Api.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RenameTextToQuestionText : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Questions",
                newName: "QuestionText");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuestionText",
                table: "Questions",
                newName: "Text");
        }
    }
}

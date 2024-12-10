using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormsIW5.Api.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RenameAnswersSelectionToQuestionOptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_AnswersSelection_SelectedAnswerId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_AnswersSelection_Questions_QuestionId",
                table: "AnswersSelection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnswersSelection",
                table: "AnswersSelection");

            migrationBuilder.RenameTable(
                name: "AnswersSelection",
                newName: "QuestionOptions");

            migrationBuilder.RenameIndex(
                name: "IX_AnswersSelection_QuestionId",
                table: "QuestionOptions",
                newName: "IX_QuestionOptions_QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionOptions",
                table: "QuestionOptions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_QuestionOptions_SelectedAnswerId",
                table: "Answers",
                column: "SelectedAnswerId",
                principalTable: "QuestionOptions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionOptions_Questions_QuestionId",
                table: "QuestionOptions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_QuestionOptions_SelectedAnswerId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionOptions_Questions_QuestionId",
                table: "QuestionOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionOptions",
                table: "QuestionOptions");

            migrationBuilder.RenameTable(
                name: "QuestionOptions",
                newName: "AnswersSelection");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionOptions_QuestionId",
                table: "AnswersSelection",
                newName: "IX_AnswersSelection_QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnswersSelection",
                table: "AnswersSelection",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_AnswersSelection_SelectedAnswerId",
                table: "Answers",
                column: "SelectedAnswerId",
                principalTable: "AnswersSelection",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswersSelection_Questions_QuestionId",
                table: "AnswersSelection",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

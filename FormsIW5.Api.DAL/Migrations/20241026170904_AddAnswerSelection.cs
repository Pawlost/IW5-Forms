using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormsIW5.Api.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddAnswerSelection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SelectedAnswerId",
                table: "Answers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AnswersSelection",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SelectionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswersSelection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswersSelection_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_SelectedAnswerId",
                table: "Answers",
                column: "SelectedAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswersSelection_QuestionId",
                table: "AnswersSelection",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_AnswersSelection_SelectedAnswerId",
                table: "Answers",
                column: "SelectedAnswerId",
                principalTable: "AnswersSelection",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_AnswersSelection_SelectedAnswerId",
                table: "Answers");

            migrationBuilder.DropTable(
                name: "AnswersSelection");

            migrationBuilder.DropIndex(
                name: "IX_Answers_SelectedAnswerId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "SelectedAnswerId",
                table: "Answers");
        }
    }
}

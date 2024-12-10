using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormsIW5.Api.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_QuestionOptions_SelectedAnswerId",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_SelectedAnswerId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "SelectedAnswerId",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "SelectionName",
                table: "QuestionOptions",
                newName: "QuestionOptionName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuestionOptionName",
                table: "QuestionOptions",
                newName: "SelectionName");

            migrationBuilder.AddColumn<Guid>(
                name: "SelectedAnswerId",
                table: "Answers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Answers_SelectedAnswerId",
                table: "Answers",
                column: "SelectedAnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_QuestionOptions_SelectedAnswerId",
                table: "Answers",
                column: "SelectedAnswerId",
                principalTable: "QuestionOptions",
                principalColumn: "Id");
        }
    }
}

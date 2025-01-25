using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormsIW5.Api.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDateProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Forms",
                newName: "FormStartDate");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Forms",
                newName: "FormEndDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FormStartDate",
                table: "Forms",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "FormEndDate",
                table: "Forms",
                newName: "EndDate");
        }
    }
}

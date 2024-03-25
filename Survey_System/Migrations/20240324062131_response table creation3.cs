using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Survey_System.Migrations
{
    /// <inheritdoc />
    public partial class responsetablecreation3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "Responses",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Answers",
                table: "Responses",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "Answers",
                table: "Responses");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Survey_System.Migrations
{
    /// <inheritdoc />
    public partial class urlcoloumnadd1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "urlid",
                table: "Surveys",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "urlid",
                table: "Surveys");
        }
    }
}

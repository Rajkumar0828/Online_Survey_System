using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Survey_System.Migrations
{
    /// <inheritdoc />
    public partial class responsetablecreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsersSurveyUserID",
                table: "Responses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Responses_UsersSurveyUserID",
                table: "Responses",
                column: "UsersSurveyUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Users_UsersSurveyUserID",
                table: "Responses",
                column: "UsersSurveyUserID",
                principalTable: "Users",
                principalColumn: "SurveyUserID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Users_UsersSurveyUserID",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Responses_UsersSurveyUserID",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "UsersSurveyUserID",
                table: "Responses");
        }
    }
}

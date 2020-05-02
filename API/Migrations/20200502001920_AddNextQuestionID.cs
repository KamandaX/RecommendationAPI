using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class AddNextQuestionID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NextQuestionID",
                table: "QuestionOptions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionOptions_NextQuestionID",
                table: "QuestionOptions",
                column: "NextQuestionID");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionOptions_Questions_NextQuestionID",
                table: "QuestionOptions",
                column: "NextQuestionID",
                principalTable: "Questions",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionOptions_Questions_NextQuestionID",
                table: "QuestionOptions");

            migrationBuilder.DropIndex(
                name: "IX_QuestionOptions_NextQuestionID",
                table: "QuestionOptions");

            migrationBuilder.DropColumn(
                name: "NextQuestionID",
                table: "QuestionOptions");
        }
    }
}

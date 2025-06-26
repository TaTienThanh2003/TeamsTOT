using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backTOT.Migrations
{
    /// <inheritdoc />
    public partial class editusertopi111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "UserVocabularys",
                type: "int",
                nullable: true);


            migrationBuilder.CreateIndex(
                name: "IX_UserVocabularys_TopicId",
                table: "UserVocabularys",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserVocabularys_Topics_TopicId",
                table: "UserVocabularys",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserVocabularys_Topics_TopicId",
                table: "UserVocabularys");

            migrationBuilder.DropIndex(
                name: "IX_UserVocabularys_TopicId",
                table: "UserVocabularys");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "UserVocabularys");

            migrationBuilder.DropColumn(
                name: "IsComplete",
                table: "UserTopics");
        }
    }
}

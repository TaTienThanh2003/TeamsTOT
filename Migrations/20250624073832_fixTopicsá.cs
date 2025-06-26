using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backTOT.Migrations
{
    /// <inheritdoc />
    public partial class fixTopicsá : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserVocabularys_Users_UsersId",
                table: "UserVocabularys");

            migrationBuilder.DropForeignKey(
                name: "FK_UserVocabularys_Vocabularys_VocabularysId",
                table: "UserVocabularys");

            migrationBuilder.DropIndex(
                name: "IX_UserVocabularys_UsersId",
                table: "UserVocabularys");

            migrationBuilder.DropIndex(
                name: "IX_UserVocabularys_VocabularysId",
                table: "UserVocabularys");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "UserVocabularys");

            migrationBuilder.DropColumn(
                name: "VocabularysId",
                table: "UserVocabularys");

            migrationBuilder.CreateIndex(
                name: "IX_UserVocabularys_Student_id",
                table: "UserVocabularys",
                column: "Student_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserVocabularys_VocabularyId",
                table: "UserVocabularys",
                column: "VocabularyId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserVocabularys_Users_Student_id",
                table: "UserVocabularys",
                column: "Student_id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserVocabularys_Vocabularys_VocabularyId",
                table: "UserVocabularys",
                column: "VocabularyId",
                principalTable: "Vocabularys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserVocabularys_Users_Student_id",
                table: "UserVocabularys");

            migrationBuilder.DropForeignKey(
                name: "FK_UserVocabularys_Vocabularys_VocabularyId",
                table: "UserVocabularys");

            migrationBuilder.DropIndex(
                name: "IX_UserVocabularys_Student_id",
                table: "UserVocabularys");

            migrationBuilder.DropIndex(
                name: "IX_UserVocabularys_VocabularyId",
                table: "UserVocabularys");

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "UserVocabularys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VocabularysId",
                table: "UserVocabularys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserVocabularys_UsersId",
                table: "UserVocabularys",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVocabularys_VocabularysId",
                table: "UserVocabularys",
                column: "VocabularysId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserVocabularys_Users_UsersId",
                table: "UserVocabularys",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserVocabularys_Vocabularys_VocabularysId",
                table: "UserVocabularys",
                column: "VocabularysId",
                principalTable: "Vocabularys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

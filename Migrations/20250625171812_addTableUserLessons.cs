using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backTOT.Migrations
{
    /// <inheritdoc />
    public partial class addTableUserLessons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLesson_Lessons_LessonsId",
                table: "UserLesson");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLesson_Users_Student_id",
                table: "UserLesson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLesson",
                table: "UserLesson");

            migrationBuilder.RenameTable(
                name: "UserLesson",
                newName: "UserLessons");

            migrationBuilder.RenameIndex(
                name: "IX_UserLesson_Student_id",
                table: "UserLessons",
                newName: "IX_UserLessons_Student_id");

            migrationBuilder.RenameIndex(
                name: "IX_UserLesson_LessonsId",
                table: "UserLessons",
                newName: "IX_UserLessons_LessonsId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsComplete",
                table: "UserLessons",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLessons",
                table: "UserLessons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLessons_Lessons_LessonsId",
                table: "UserLessons",
                column: "LessonsId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLessons_Users_Student_id",
                table: "UserLessons",
                column: "Student_id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLessons_Lessons_LessonsId",
                table: "UserLessons");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLessons_Users_Student_id",
                table: "UserLessons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLessons",
                table: "UserLessons");

            migrationBuilder.RenameTable(
                name: "UserLessons",
                newName: "UserLesson");

            migrationBuilder.RenameIndex(
                name: "IX_UserLessons_Student_id",
                table: "UserLesson",
                newName: "IX_UserLesson_Student_id");

            migrationBuilder.RenameIndex(
                name: "IX_UserLessons_LessonsId",
                table: "UserLesson",
                newName: "IX_UserLesson_LessonsId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsComplete",
                table: "UserLesson",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLesson",
                table: "UserLesson",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLesson_Lessons_LessonsId",
                table: "UserLesson",
                column: "LessonsId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLesson_Users_Student_id",
                table: "UserLesson",
                column: "Student_id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

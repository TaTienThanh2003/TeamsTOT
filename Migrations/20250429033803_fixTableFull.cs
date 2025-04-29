using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backTOT.Migrations
{
    /// <inheritdoc />
    public partial class fixTableFull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Courses_Courses_id",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "Courses_id",
                table: "Lessons",
                newName: "Section_id");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Lessons",
                newName: "DesVI");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_Courses_id",
                table: "Lessons",
                newName: "IX_Lessons_Section_id");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Courses",
                newName: "DesVI");

            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "Lessons",
                type: "bit",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DesEN",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TitleEN",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TitleVI",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DesEN",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleEN",
                table: "Courses",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TitleVI",
                table: "Courses",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lesson_id = table.Column<int>(type: "int", nullable: false),
                    User_id = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    DisLikes = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Parent_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Lessons_Lesson_id",
                        column: x => x.Lesson_id,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lesson_notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lesson_id = table.Column<int>(type: "int", nullable: false),
                    User_id = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Video_time = table.Column<TimeSpan>(type: "time", nullable: false),
                    created_ad = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesson_notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lesson_notes_Lessons_Lesson_id",
                        column: x => x.Lesson_id,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lesson_notes_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleVI = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TitleEN = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DesVI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesEN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TrialPeriodDays = table.Column<int>(type: "int", nullable: false, defaultValue: 30)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleVI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DesVI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesEN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Courses_id = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_Courses_Courses_id",
                        column: x => x.Courses_id,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_plans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_id = table.Column<int>(type: "int", nullable: false),
                    Plan_id = table.Column<int>(type: "int", nullable: false),
                    Start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    End_date = table.Column<DateOnly>(type: "date", nullable: true),
                    created_ad = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "ACTIVE")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_plans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_plans_Plans_Plan_id",
                        column: x => x.Plan_id,
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_plans_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Lesson_id",
                table: "Comments",
                column: "Lesson_id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_User_id",
                table: "Comments",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_notes_Lesson_id",
                table: "Lesson_notes",
                column: "Lesson_id");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_notes_User_id",
                table: "Lesson_notes",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_Courses_id",
                table: "Sections",
                column: "Courses_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_plans_Plan_id",
                table: "User_plans",
                column: "Plan_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_plans_User_id",
                table: "User_plans",
                column: "User_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Sections_Section_id",
                table: "Lessons",
                column: "Section_id",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Sections_Section_id",
                table: "Lessons");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Lesson_notes");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "User_plans");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropColumn(
                name: "Completed",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "DesEN",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "TitleEN",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "TitleVI",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "DesEN",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "TitleEN",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "TitleVI",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "Section_id",
                table: "Lessons",
                newName: "Courses_id");

            migrationBuilder.RenameColumn(
                name: "DesVI",
                table: "Lessons",
                newName: "Content");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_Section_id",
                table: "Lessons",
                newName: "IX_Lessons_Courses_id");

            migrationBuilder.RenameColumn(
                name: "DesVI",
                table: "Courses",
                newName: "Description");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Lessons",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Courses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Courses_Courses_id",
                table: "Lessons",
                column: "Courses_id",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

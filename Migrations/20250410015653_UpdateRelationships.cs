using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backTOT.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Des = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "USER"),
                    created_ad = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Teacher_id = table.Column<int>(type: "int", nullable: false),
                    CountDay = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Mode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Users_Teacher_id",
                        column: x => x.Teacher_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Student_id = table.Column<int>(type: "int", nullable: false),
                    Courses_id = table.Column<int>(type: "int", nullable: false),
                    Start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    End_date = table.Column<DateOnly>(type: "date", nullable: false),
                    created_ad = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_Courses_id",
                        column: x => x.Courses_id,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Users_Student_id",
                        column: x => x.Student_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Courses_id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Video_url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Courses_Courses_id",
                        column: x => x.Courses_id,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Student_id = table.Column<int>(type: "int", nullable: false),
                    Courses_id = table.Column<int>(type: "int", nullable: false),
                    Test_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Score = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Date_taken = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scores_Courses_Courses_id",
                        column: x => x.Courses_id,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Scores_Users_Student_id",
                        column: x => x.Student_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Courses_id = table.Column<int>(type: "int", nullable: false),
                    Lessons_id = table.Column<int>(type: "int", nullable: false),
                    Class_time = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Courses_Courses_id",
                        column: x => x.Courses_id,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedules_Lessons_Lessons_id",
                        column: x => x.Lessons_id,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Teacher_id",
                table: "Courses",
                column: "Teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_Courses_id",
                table: "Enrollments",
                column: "Courses_id");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_Student_id",
                table: "Enrollments",
                column: "Student_id");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_Courses_id",
                table: "Lessons",
                column: "Courses_id");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_Courses_id",
                table: "Schedules",
                column: "Courses_id");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_Lessons_id",
                table: "Schedules",
                column: "Lessons_id");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_Courses_id",
                table: "Scores",
                column: "Courses_id");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_Student_id",
                table: "Scores",
                column: "Student_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Scores");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

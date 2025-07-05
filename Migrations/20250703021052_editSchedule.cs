using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backTOT.Migrations
{
    /// <inheritdoc />
    public partial class editSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Lessons_Lessons_id",
                table: "Schedules");

            migrationBuilder.RenameColumn(
                name: "Lessons_id",
                table: "Schedules",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "Class_time",
                table: "Schedules",
                newName: "Start_date");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_Lessons_id",
                table: "Schedules",
                newName: "IX_Schedules_StudentId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Schedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DayOfWeek",
                table: "Schedules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "End_date",
                table: "Schedules",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeLearn",
                table: "Schedules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Users_StudentId",
                table: "Schedules",
                column: "StudentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Users_StudentId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "End_date",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "TimeLearn",
                table: "Schedules");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Schedules",
                newName: "Lessons_id");

            migrationBuilder.RenameColumn(
                name: "Start_date",
                table: "Schedules",
                newName: "Class_time");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_StudentId",
                table: "Schedules",
                newName: "IX_Schedules_Lessons_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Lessons_Lessons_id",
                table: "Schedules",
                column: "Lessons_id",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

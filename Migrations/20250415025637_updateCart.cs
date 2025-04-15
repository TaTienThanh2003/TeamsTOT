using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backTOT.Migrations
{
    /// <inheritdoc />
    public partial class updateCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CourseId",
                table: "Carts",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Courses_CourseId",
                table: "Carts",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Courses_CourseId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_CourseId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Carts");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backTOT.Migrations
{
    /// <inheritdoc />
    public partial class addColumTopics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsersCreated_id",
                table: "Topics",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Topics_UsersCreated_id",
                table: "Topics",
                column: "UsersCreated_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Users_UsersCreated_id",
                table: "Topics",
                column: "UsersCreated_id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Users_UsersCreated_id",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Topics_UsersCreated_id",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "UsersCreated_id",
                table: "Topics");
        }
    }
}

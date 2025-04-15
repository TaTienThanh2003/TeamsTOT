using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backTOT.Migrations
{
    /// <inheritdoc />
    public partial class relationCartUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Carts_Users_id",
                table: "Carts",
                column: "Users_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_Users_id",
                table: "Carts",
                column: "Users_id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_Users_id",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_Users_id",
                table: "Carts");
        }
    }
}

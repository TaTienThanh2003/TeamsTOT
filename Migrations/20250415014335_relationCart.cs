using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backTOT.Migrations
{
    /// <inheritdoc />
    public partial class relationCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_Users_id",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_Users_id",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Carts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Carts",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

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
    }
}

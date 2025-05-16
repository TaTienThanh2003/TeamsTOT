using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backTOT.Migrations
{
    /// <inheritdoc />
    public partial class AddTableCatalog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CatalogId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Num",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Catalogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DesVI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesEN = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CatalogId",
                table: "Courses",
                column: "CatalogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Catalogs_CatalogId",
                table: "Courses",
                column: "CatalogId",
                principalTable: "Catalogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Catalogs_CatalogId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "Catalogs");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CatalogId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CatalogId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Num",
                table: "Courses");
        }
    }
}

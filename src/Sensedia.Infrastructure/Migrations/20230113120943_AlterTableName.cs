#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace Sensedia.API.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Products_XPTO");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products_XPTO",
                table: "Products_XPTO",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products_XPTO",
                table: "Products_XPTO");

            migrationBuilder.RenameTable(
                name: "Products_XPTO",
                newName: "Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sensedia.API.Migrations
{
    /// <inheritdoc />
    public partial class RevertAlterFieldOldNameProductName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products_XPTO",
                table: "Products_XPTO");

            migrationBuilder.RenameTable(
                name: "Products_XPTO",
                newName: "Products");

            migrationBuilder.RenameColumn(
                name: "Product_Name",
                table: "Products",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Products_XPTO");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products_XPTO",
                newName: "Product_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products_XPTO",
                table: "Products_XPTO",
                column: "Id");
        }
    }
}

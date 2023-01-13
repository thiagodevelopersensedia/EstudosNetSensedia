using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sensedia.API.Migrations
{
    /// <inheritdoc />
    public partial class AlterFieldOldNameProductName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products_XPTO",
                newName: "Product_Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Product_Name",
                table: "Products_XPTO",
                newName: "Name");
        }
    }
}

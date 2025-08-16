using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzShop.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class editbrandaddimage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Brands",
                newName: "Image");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Brands",
                newName: "Name");
        }
    }
}

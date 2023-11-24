using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMenus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Menus");
        }
    }
}

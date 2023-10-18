using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initsss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartStatus",
                table: "Carts",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartStatus",
                table: "Carts");
        }
    }
}

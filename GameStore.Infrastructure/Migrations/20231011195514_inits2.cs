using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class inits2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Carts_CartId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_CartId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "GameIds",
                table: "Carts");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Carts",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_GameId",
                table: "Carts",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Games_GameId",
                table: "Carts",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Games_GameId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_GameId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Carts");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Games",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<List<int>>(
                name: "GameIds",
                table: "Carts",
                type: "integer[]",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_CartId",
                table: "Games",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Carts_CartId",
                table: "Games",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");
        }
    }
}

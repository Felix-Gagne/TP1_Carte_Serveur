using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Super_Cartes_Infinies.Migrations
{
    /// <inheritdoc />
    public partial class OwnedCardCardFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4cf108b-9230-46d2-8703-863006bf0a08", "AQAAAAIAAYagAAAAEEl2L+zCe018JwJUmzORSC0ItdIu5Cj6oG+fxLLKPkbJmXsNhGYq0LmiUI90GNqWYg==", "1600a964-08ad-4ea7-89af-463d0c6d87d8" });

            migrationBuilder.CreateIndex(
                name: "IX_OwnedCards_CardId",
                table: "OwnedCards",
                column: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_OwnedCards_Cards_CardId",
                table: "OwnedCards",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OwnedCards_Cards_CardId",
                table: "OwnedCards");

            migrationBuilder.DropIndex(
                name: "IX_OwnedCards_CardId",
                table: "OwnedCards");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d49248d8-97cb-44fd-a9e9-c0b710c04e64", "AQAAAAIAAYagAAAAENfk3fGUsRo/lUGyrOqXyC0y/WSZ//2QNJu5H4/5eRrlFHa9lCYuwVJweK2G6I9dyQ==", "76f5d519-b486-4492-94a5-b93d60767377" });
        }
    }
}

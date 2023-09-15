using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Super_Cartes_Infinies.Migrations
{
    /// <inheritdoc />
    public partial class CardPlayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Players_PlayerId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_PlayerId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Cards");

            migrationBuilder.CreateTable(
                name: "CardPlayer",
                columns: table => new
                {
                    DeckCardId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlayersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardPlayer", x => new { x.DeckCardId, x.PlayersId });
                    table.ForeignKey(
                        name: "FK_CardPlayer_Cards_DeckCardId",
                        column: x => x.DeckCardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardPlayer_Players_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53c61fe2-e216-483a-b00e-7feebf28984d", "AQAAAAIAAYagAAAAEDnkDUTKXdsd9wFG6a+5yM6to3yfnItDLphE9ANAXIZT7QjuDyZ+dpYb8TcMSKJ3Ug==", "b94edcf5-1e1a-42bc-9aca-8ea64035b3e7" });

            migrationBuilder.CreateIndex(
                name: "IX_CardPlayer_PlayersId",
                table: "CardPlayer",
                column: "PlayersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardPlayer");

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "Cards",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f3a70b9d-3165-4aa2-89de-82aeda71e4f2", "AQAAAAIAAYagAAAAEEMie+Rjl8D3vInD1IMPkGK4BJMmJIJQlBuSf4fVKm9QVj7uLeZUpXFbPqdcrt1lyQ==", "0aeeb62b-9dce-4aad-aec6-0488d721e4be" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1,
                column: "PlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2,
                column: "PlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 3,
                column: "PlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 4,
                column: "PlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 5,
                column: "PlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 6,
                column: "PlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 7,
                column: "PlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 8,
                column: "PlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 9,
                column: "PlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 10,
                column: "PlayerId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_PlayerId",
                table: "Cards",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Players_PlayerId",
                table: "Cards",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id");
        }
    }
}

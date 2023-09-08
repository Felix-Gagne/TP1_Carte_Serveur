using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Super_Cartes_Infinies.Migrations
{
    /// <inheritdoc />
    public partial class updateApresMerge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f3a70b9d-3165-4aa2-89de-82aeda71e4f2", "AQAAAAIAAYagAAAAEEMie+Rjl8D3vInD1IMPkGK4BJMmJIJQlBuSf4fVKm9QVj7uLeZUpXFbPqdcrt1lyQ==", "0aeeb62b-9dce-4aad-aec6-0488d721e4be" });

            migrationBuilder.CreateIndex(
                name: "IX_StartingCards_CardId",
                table: "StartingCards",
                column: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_StartingCards_Cards_CardId",
                table: "StartingCards",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StartingCards_Cards_CardId",
                table: "StartingCards");

            migrationBuilder.DropIndex(
                name: "IX_StartingCards_CardId",
                table: "StartingCards");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ddc0a585-3d8d-4c9e-ac7d-74bab216d029", "AQAAAAIAAYagAAAAEBc43XJbRQWTIUftaack6KKZ3k2aWUhdOZzCpETjxpILNhJE4pb2woEuxrQdb1rhtA==", "84f6fa56-23a4-4da7-9be4-d6c0310d2b22" });
        }
    }
}

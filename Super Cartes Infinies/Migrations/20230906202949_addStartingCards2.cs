using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Super_Cartes_Infinies.Migrations
{
    /// <inheritdoc />
    public partial class addStartingCards2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68d7053a-9685-4a83-bf94-d67e76898cea", "AQAAAAIAAYagAAAAEBLsfupNjWLBEgghaZS/Q0xh2DWvK9VDiiriGxKNeA5gVsn03Ouc+EAvOV7EvBM7vQ==", "390593a4-2950-4431-a03f-d28aa596663b" });

            migrationBuilder.InsertData(
                table: "StartingCards",
                columns: new[] { "Id", "CardId" },
                values: new object[] { 11, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StartingCards",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b83abc0-5f25-4f86-9104-940f8cac764c", "AQAAAAIAAYagAAAAEP52d6IMz/D7dPxlLvy50NZKIPUlxQkXndYu2A/Okr8udoJbzxQNzfrnEkbfLM4gHA==", "be687b6a-91aa-48a6-9cf1-ad74fe1b2cb9" });
        }
    }
}

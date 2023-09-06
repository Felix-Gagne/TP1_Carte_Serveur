using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Super_Cartes_Infinies.Migrations
{
    /// <inheritdoc />
    public partial class addStartingCards3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40b9e815-afd5-402c-ac1c-d353bcd9c660", "AQAAAAIAAYagAAAAELsKFvHALSba1PJ0odaXykDNSwNwYdiZuhl3KvwSC38kBpyr7XTVwrDCQ952fP6t+Q==", "bed9d666-9012-447b-9583-4ec055564cf8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68d7053a-9685-4a83-bf94-d67e76898cea", "AQAAAAIAAYagAAAAEBLsfupNjWLBEgghaZS/Q0xh2DWvK9VDiiriGxKNeA5gVsn03Ouc+EAvOV7EvBM7vQ==", "390593a4-2950-4431-a03f-d28aa596663b" });
        }
    }
}

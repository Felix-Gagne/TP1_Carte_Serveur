using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Super_Cartes_Infinies.Migrations
{
    /// <inheritdoc />
    public partial class addPoison : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Poisoned",
                table: "PlayableCard",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SummonSickness",
                table: "PlayableCard",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4020629-7a55-4c38-ac3d-7477f093017e", "AQAAAAIAAYagAAAAEPkeaWHbPseey74xiWbflmH9J1CvkiuBEHmHruSEy6TH1+w2pDKTA4Rr0ME8Ar1r6Q==", "53a9f9ee-acd0-4a47-bab3-f0ffba1d30cd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Poisoned",
                table: "PlayableCard");

            migrationBuilder.DropColumn(
                name: "SummonSickness",
                table: "PlayableCard");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4beff6f6-b59c-4d4c-bf0f-d8996901c4d8", "AQAAAAIAAYagAAAAEIFmyz3Y9/Syr+dikow1xRqX4mO3TcYFpliT3V9RDCASzuiN1q/qjYD4Nbk3wEcZgw==", "13032867-ed0d-435b-b51b-cb1c3ef08280" });
        }
    }
}

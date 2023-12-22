using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Super_Cartes_Infinies.Migrations
{
    /// <inheritdoc />
    public partial class newPowers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PoisonedLevel",
                table: "PlayableCard",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StunTurnLeft",
                table: "PlayableCard",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Stuned",
                table: "PlayableCard",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59d19083-d177-4112-967b-5dbb4e6ab3f8", "AQAAAAIAAYagAAAAEKk037BjW0c7Jsh4FQqoOnLuTFNu/M+Do4FeF/6AQiWMkI6MxVzum8knS+iNmY7sZQ==", "37f9ad68-d802-4991-947b-848522e59341" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PoisonedLevel",
                table: "PlayableCard");

            migrationBuilder.DropColumn(
                name: "StunTurnLeft",
                table: "PlayableCard");

            migrationBuilder.DropColumn(
                name: "Stuned",
                table: "PlayableCard");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4020629-7a55-4c38-ac3d-7477f093017e", "AQAAAAIAAYagAAAAEPkeaWHbPseey74xiWbflmH9J1CvkiuBEHmHruSEy6TH1+w2pDKTA4Rr0ME8Ar1r6Q==", "53a9f9ee-acd0-4a47-bab3-f0ffba1d30cd" });
        }
    }
}

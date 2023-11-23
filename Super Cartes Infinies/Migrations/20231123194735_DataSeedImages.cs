using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Super_Cartes_Infinies.Migrations
{
    /// <inheritdoc />
    public partial class DataSeedImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c983a9c2-714c-4278-b708-e280254f9824", "AQAAAAIAAYagAAAAEJ2Px5me8FZEPz0A+1XC/+LovCt4q6A+RUIDGr1dKStG9+RLufPKLAftalgYjiQp7w==", "cdd3aa70-97d7-4a3f-a3e7-018520e65b3c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36c7814f-3ba1-4426-8f1b-88e34539a372", "AQAAAAIAAYagAAAAEHijjIr/IzXV9Pr1e7MtmYCeexF7cWlaquCCH2Phs+xtXi+3sNNiYnVHXsoGVXYcRg==", "6411c0ec-e134-41f1-ad77-312c9c8f37b5" });
        }
    }
}

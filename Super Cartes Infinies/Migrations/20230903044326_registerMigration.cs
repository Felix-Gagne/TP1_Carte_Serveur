using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Super_Cartes_Infinies.Migrations
{
    /// <inheritdoc />
    public partial class registerMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "319c2e40-96ae-45be-8c22-46dd6548aa61", "AQAAAAIAAYagAAAAEAGfpvX/Y4ri/fJQqXZJhdlUJQp6BWJe6rvBLSNKDI8w7F8ghUVNFKTeWRrH4GpJZA==", "f53e4899-232f-477c-8e71-766bb58d8c48" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8dac2698-27b2-4999-b2ab-fc13583b8170", "AQAAAAIAAYagAAAAEHX2T7Gs4LJ+HogTy6RZRMJ7mjO8giD67vb3abMAcJi15TPpz4v5EV38Xpwst2TRwg==", "d3e0d8bd-fd75-424d-a44e-8d26a8f5712c" });
        }
    }
}

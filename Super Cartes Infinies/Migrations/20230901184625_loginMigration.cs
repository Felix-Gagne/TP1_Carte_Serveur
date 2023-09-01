using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Super_Cartes_Infinies.Migrations
{
    /// <inheritdoc />
    public partial class loginMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8dac2698-27b2-4999-b2ab-fc13583b8170", "AQAAAAIAAYagAAAAEHX2T7Gs4LJ+HogTy6RZRMJ7mjO8giD67vb3abMAcJi15TPpz4v5EV38Xpwst2TRwg==", "d3e0d8bd-fd75-424d-a44e-8d26a8f5712c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f37d8d41-b7b5-4427-a3e1-d3320de6ca5d", "AQAAAAIAAYagAAAAELxHr1w4Y9Bgc9OKYqN3Oevuy/k46UCWUH5an27Q6XJ8aKl+rKZsgD1k2SOFiIGTRg==", "192a0d98-ea29-44cd-8de7-2db4676a173f" });
        }
    }
}

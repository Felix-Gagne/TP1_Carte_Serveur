using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Super_Cartes_Infinies.Migrations
{
    /// <inheritdoc />
    public partial class login : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cdd706ca-2ccd-42d1-a708-96315d6efc02", "AQAAAAIAAYagAAAAEHhDBUID/INzR3pFxKnJMkBIb7J/PhmpJFWfOr9KMUSuAg9zXIyOaFcgDv5k1mXTDQ==", "5ec803d4-e64e-46cf-b450-4aee9f593767" });
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

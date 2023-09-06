using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Super_Cartes_Infinies.Migrations
{
    /// <inheritdoc />
    public partial class ModifiactionDataseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c0f51721-bfb8-4068-a664-019d88705774", "AQAAAAIAAYagAAAAEBlDPGYDjaVrwnDcXcwTqYUOEzgRzr+3Ozg55Spwq1KY7rvaL2GUpxH2RDkp7cJrug==", "90913964-38d9-4c86-a363-f252b800fbde" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cdd706ca-2ccd-42d1-a708-96315d6efc02", "AQAAAAIAAYagAAAAEHhDBUID/INzR3pFxKnJMkBIb7J/PhmpJFWfOr9KMUSuAg9zXIyOaFcgDv5k1mXTDQ==", "5ec803d4-e64e-46cf-b450-4aee9f593767" });
        }
    }
}

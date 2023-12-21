using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Super_Cartes_Infinies.Migrations
{
    /// <inheritdoc />
    public partial class Stats_Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Loses",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Wins",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e91aeac2-514d-4b36-92ba-79a7ef0c76a4", "AQAAAAIAAYagAAAAEAuUH44BMr60sH0qk3gi4hQ9osFeci3EV+3m7K+1/javC+PCILQM6qKF1yFCUU3Stw==", "8fe20d3f-47fd-41f5-84ae-ce1ce0452b06" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Loses",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Wins",
                table: "Players");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f63b43b7-f41e-4c8e-9502-273b1be2c866", "AQAAAAIAAYagAAAAEBcIQPkuIjcZWwWpmVX5voNE/81RvETKIgFYpYD1ZWZNkrfeD3hQNET1B4Ya65VfQA==", "fc55c50b-d180-42a6-8fd0-4bd70e2d37bc" });
        }
    }
}

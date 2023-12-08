using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Super_Cartes_Infinies.Migrations
{
    /// <inheritdoc />
    public partial class MatchTaskAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SummonSickness",
                table: "PlayableCard",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "MatchTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    IsCompleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchTasks", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f63b43b7-f41e-4c8e-9502-273b1be2c866", "AQAAAAIAAYagAAAAEBcIQPkuIjcZWwWpmVX5voNE/81RvETKIgFYpYD1ZWZNkrfeD3hQNET1B4Ya65VfQA==", "fc55c50b-d180-42a6-8fd0-4bd70e2d37bc" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchTasks");

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

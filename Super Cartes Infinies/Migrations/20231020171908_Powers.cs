using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Super_Cartes_Infinies.Migrations
{
    /// <inheritdoc />
    public partial class Powers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1356dd7b-65b6-4fdf-97d8-208798cc979e", "AQAAAAIAAYagAAAAEIc1F+O8bz2cW5/NPCGqGgfY4OuhQ6MleVHH0VDdhF+9sk12Ohzy2YbTU7/aDcB4Bg==", "7fdea458-d445-478c-bd79-43d2a4521c25" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a1634600-6ab4-4162-b5ee-28b3b9f574b8", "AQAAAAIAAYagAAAAEA/innTg+RDU43YJX/b0UGtsv0KWoRUGt5SN+QBDNKYT+Q4E5fjmrFIdMfG7ListBQ==", "4ceb0a0f-5b69-4581-b13d-eab3ebe9a772" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Super_Cartes_Infinies.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f6f1017-28cf-48c1-b19b-467fe283b166", "AQAAAAIAAYagAAAAEIuc8NuSPWJlH8FVcFxsygQpMUNI9d85htQQYLDM5BTli0gtp843hiFrsR5/T1G/9g==", "9b7809da-6afa-4af3-a77a-9cd27325e700" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d7d1a23c-d972-4628-8f0a-fd7f94445a15", "AQAAAAIAAYagAAAAEDzTQgwrfHEl3SQtkX40fbsAg0nmJxvT/5NvtBtzc18bzdNrgk1T2bk1p2FkH17Cvg==", "c8e32ee0-659b-4536-a96b-5fe2b0a7ae8d" });
        }
    }
}

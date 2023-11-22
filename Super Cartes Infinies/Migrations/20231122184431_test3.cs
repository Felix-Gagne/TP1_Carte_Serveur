using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Super_Cartes_Infinies.Migrations
{
    /// <inheritdoc />
    public partial class test3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca8a5d34-d826-485f-b7c5-8888c09acf78", "AQAAAAIAAYagAAAAEHVuU9K+ME2DcOais2003vUZN7fWWJ3LKcQ7Rcanz8PL0bGYBuPOoQUi6ep0er7qFw==", "25e3239f-beea-4272-ac6d-d61622983186" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f6f1017-28cf-48c1-b19b-467fe283b166", "AQAAAAIAAYagAAAAEIuc8NuSPWJlH8FVcFxsygQpMUNI9d85htQQYLDM5BTli0gtp843hiFrsR5/T1G/9g==", "9b7809da-6afa-4af3-a77a-9cd27325e700" });
        }
    }
}

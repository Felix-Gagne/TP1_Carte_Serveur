using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Super_Cartes_Infinies.Migrations
{
    /// <inheritdoc />
    public partial class NewCards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "363d065b-5088-4972-8df1-98c3a3e13679", "AQAAAAIAAYagAAAAENT17jMVaH7y/3mvwDk5yNRilCoBSuFseGvMT29bTjVIImySiH/jmNguRUXxh+OvFw==", "92f94218-313a-4845-b6c0-31bb433d55ff" });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "Attack", "Defense", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 11, 4, 6, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Sketchpad Sally" },
                    { 12, 6, 3, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Chalkboard Chuck" },
                    { 13, 5, 5, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Notebook Ned" },
                    { 14, 7, 2, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Penelope Pencil" },
                    { 15, 3, 7, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Highlighter Hank" },
                    { 16, 6, 4, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Marker Mary" },
                    { 17, 7, 3, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Crayola Carl" },
                    { 18, 5, 6, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Paperclip Paula" },
                    { 19, 8, 2, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Paint Paddy" },
                    { 20, 6, 5, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Pencil Shavings Pete" },
                    { 21, 7, 4, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Sticky Stan" },
                    { 22, 5, 7, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Charcoal Charlie" },
                    { 23, 8, 3, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Watercolor Wendy" },
                    { 24, 6, 6, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Notebook Nikki" },
                    { 25, 9, 2, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Etch-a-Sketch Eddie" },
                    { 26, 4, 8, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Glitter Glenda" },
                    { 27, 7, 5, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Crayonbox Casey" },
                    { 28, 8, 4, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Sketchbook Simon" },
                    { 29, 6, 7, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Quill Quentin" },
                    { 30, 9, 3, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Sidewalk Chalk Chloe" },
                    { 31, 7, 6, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Canvas Cathy" },
                    { 32, 8, 5, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Fountain Pen Fred" },
                    { 33, 6, 8, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Sticky Note Steve" },
                    { 34, 9, 4, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Doodle Pad Donna" },
                    { 35, 7, 7, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Paint Can Patrick" },
                    { 36, 5, 9, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Marker Maze Max" },
                    { 37, 8, 6, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Etch-a-Sketch Emma" },
                    { 38, 9, 5, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Charcoal Chip" },
                    { 39, 6, 9, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Graphite Gabby" },
                    { 40, 10, 4, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Inkwell Ike" },
                    { 41, 7, 8, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Sketchbook Skyler" },
                    { 42, 10, 5, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Chalky Charles" },
                    { 43, 8, 7, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Color Wheel Casey" },
                    { 44, 9, 6, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Canvas Cleo" },
                    { 45, 6, 10, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Sticker Sue" },
                    { 46, 7, 9, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Glue Gun Gary" },
                    { 47, 10, 6, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Markerboard Molly" },
                    { 48, 8, 8, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Pixel Pete" },
                    { 49, 9, 7, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Lithography Lily" },
                    { 50, 10, 7, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", "Silkscreening Simon" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53c61fe2-e216-483a-b00e-7feebf28984d", "AQAAAAIAAYagAAAAEDnkDUTKXdsd9wFG6a+5yM6to3yfnItDLphE9ANAXIZT7QjuDyZ+dpYb8TcMSKJ3Ug==", "b94edcf5-1e1a-42bc-9aca-8ea64035b3e7" });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Super_Cartes_Infinies.Migrations
{
    /// <inheritdoc />
    public partial class initialeCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ManaCost = table.Column<int>(type: "INTEGER", nullable: false),
                    Attack = table.Column<int>(type: "INTEGER", nullable: false),
                    Defense = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MatchPlayersData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Health = table.Column<int>(type: "INTEGER", nullable: false),
                    Mana = table.Column<int>(type: "INTEGER", nullable: false),
                    PlayerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchPlayersData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Powers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Icon = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Powers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Money = table.Column<int>(type: "INTEGER", nullable: false),
                    IdentityUserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StartingCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CardId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StartingCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StartingCards_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsPlayerATurn = table.Column<bool>(type: "INTEGER", nullable: false),
                    EventIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    IsMatchCompleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    WinnerUserId = table.Column<string>(type: "TEXT", nullable: true),
                    UserAId = table.Column<string>(type: "TEXT", nullable: false),
                    UserBId = table.Column<string>(type: "TEXT", nullable: false),
                    PlayerDataAId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlayerDataBId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_MatchPlayersData_PlayerDataAId",
                        column: x => x.PlayerDataAId,
                        principalTable: "MatchPlayersData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matches_MatchPlayersData_PlayerDataBId",
                        column: x => x.PlayerDataBId,
                        principalTable: "MatchPlayersData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlayableCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CardId = table.Column<int>(type: "INTEGER", nullable: false),
                    Health = table.Column<int>(type: "INTEGER", nullable: false),
                    MatchPlayerDataId = table.Column<int>(type: "INTEGER", nullable: true),
                    MatchPlayerDataId1 = table.Column<int>(type: "INTEGER", nullable: true),
                    MatchPlayerDataId2 = table.Column<int>(type: "INTEGER", nullable: true),
                    MatchPlayerDataId3 = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayableCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayableCard_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayableCard_MatchPlayersData_MatchPlayerDataId",
                        column: x => x.MatchPlayerDataId,
                        principalTable: "MatchPlayersData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayableCard_MatchPlayersData_MatchPlayerDataId1",
                        column: x => x.MatchPlayerDataId1,
                        principalTable: "MatchPlayersData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayableCard_MatchPlayersData_MatchPlayerDataId2",
                        column: x => x.MatchPlayerDataId2,
                        principalTable: "MatchPlayersData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayableCard_MatchPlayersData_MatchPlayerDataId3",
                        column: x => x.MatchPlayerDataId3,
                        principalTable: "MatchPlayersData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CardPowers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CardId = table.Column<int>(type: "INTEGER", nullable: false),
                    PowerId = table.Column<int>(type: "INTEGER", nullable: false),
                    value = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardPowers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardPowers_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardPowers_Powers_PowerId",
                        column: x => x.PowerId,
                        principalTable: "Powers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardPlayer",
                columns: table => new
                {
                    DeckCardId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlayersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardPlayer", x => new { x.DeckCardId, x.PlayersId });
                    table.ForeignKey(
                        name: "FK_CardPlayer_Cards_DeckCardId",
                        column: x => x.DeckCardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardPlayer_Players_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SerializedMatchEvent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    SerializedEvent = table.Column<string>(type: "TEXT", nullable: false),
                    MatchId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerializedMatchEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SerializedMatchEvent_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "11111111-1111-1111-1111-111111111111", 0, "73f6993d-8f76-4523-9920-e27ada8327b2", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEKBHY5ZdmRJXvAxiCJOAhjZ7Zvdj7eudcAPVDwJ6KGrxUWbeUXe+dBh9nNT47lI6kg==", null, false, "985dcbf8-d481-46d2-9fc4-79d807b23948", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "Attack", "Defense", "ImageUrl", "ManaCost", "Name" },
                values: new object[,]
                {
                    { 1, 3, 3, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 2, "Stickly Steve" },
                    { 2, 2, 4, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 1, "Sketchy Sarah" },
                    { 3, 4, 2, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 2, "Doodle Dave" },
                    { 4, 3, 5, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 3, "Pencil Pete" },
                    { 5, 4, 4, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 3, "Marker Mike" },
                    { 6, 2, 6, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 2, "Eraser Edith" },
                    { 7, 5, 3, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 4, "Crayon Carla" },
                    { 8, 4, 5, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 3, "Scribble Sam" },
                    { 9, 6, 2, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 2, "Inkwell Ivan" },
                    { 10, 5, 4, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 3, "Paintbrush Penny" },
                    { 11, 4, 6, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 3, "Sketchpad Sally" },
                    { 12, 6, 3, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 3, "Chalkboard Chuck" },
                    { 13, 5, 5, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 3, "Notebook Ned" },
                    { 14, 7, 2, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 2, "Penelope Pencil" },
                    { 15, 3, 7, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 4, "Highlighter Hank" },
                    { 16, 6, 4, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 4, "Marker Mary" },
                    { 17, 7, 3, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 2, "Crayola Carl" },
                    { 18, 5, 6, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 5, "Paperclip Paula" },
                    { 19, 8, 2, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 3, "Paint Paddy" },
                    { 20, 6, 5, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 4, "Pencil Shavings Pete" },
                    { 21, 7, 4, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 3, "Sticky Stan" },
                    { 22, 5, 7, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 7, "Charcoal Charlie" },
                    { 23, 8, 3, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 2, "Watercolor Wendy" },
                    { 24, 6, 6, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 5, "Notebook Nikki" },
                    { 25, 9, 2, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 3, "Etch-a-Sketch Eddie" },
                    { 26, 4, 8, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 4, "Glitter Glenda" },
                    { 27, 7, 5, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 5, "Crayonbox Casey" },
                    { 28, 8, 4, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 5, "Sketchbook Simon" },
                    { 29, 6, 7, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 5, "Quill Quentin" },
                    { 30, 9, 3, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 4, "Sidewalk Chalk Chloe" },
                    { 31, 7, 6, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 4, "Canvas Cathy" },
                    { 32, 11, 10, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 8, "Fountain Pen Fred" },
                    { 33, 6, 8, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 6, "Sticky Note Steve" },
                    { 34, 9, 4, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 4, "Doodle Pad Donna" },
                    { 35, 7, 7, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 7, "Paint Can Patrick" },
                    { 36, 5, 9, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 7, "Marker Maze Max" },
                    { 37, 8, 6, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 4, "Etch-a-Sketch Emma" },
                    { 38, 9, 5, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 5, "Charcoal Chip" },
                    { 39, 8, 9, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 10, "Graphite Gabby" },
                    { 40, 10, 4, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 5, "Inkwell Ike" },
                    { 41, 7, 8, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 5, "Sketchbook Skyler" },
                    { 42, 10, 5, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 7, "Chalky Charles" },
                    { 43, 8, 7, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 6, "Color Wheel Casey" },
                    { 44, 9, 6, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 5, "Canvas Cleo" },
                    { 45, 6, 10, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 8, "Sticker Sue" },
                    { 46, 7, 9, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 5, "Glue Gun Gary" },
                    { 47, 10, 6, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 7, "Markerboard Molly" },
                    { 48, 8, 8, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 7, "Pixel Pete" },
                    { 49, 15, 15, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 20, "Lithography Lily" },
                    { 50, 10, 7, "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png", 8, "Silkscreening Simon" }
                });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[,]
                {
                    { 1, "https://static.thenounproject.com/png/1776468-200.png", "Charge" },
                    { 2, "https://static.thenounproject.com/png/1776468-200.png", "First Strike" },
                    { 3, "https://static.thenounproject.com/png/1776468-200.png", "Thorns" },
                    { 4, "https://static.thenounproject.com/png/1776468-200.png", "Heal" },
                    { 5, "https://static.thenounproject.com/png/1776468-200.png", "Explosion" },
                    { 6, "https://static.thenounproject.com/png/1776468-200.png", "Greed" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "11111111-1111-1111-1111-111111111111" });

            migrationBuilder.InsertData(
                table: "CardPowers",
                columns: new[] { "Id", "CardId", "PowerId", "value" },
                values: new object[,]
                {
                    { 1, 1, 1, 0 },
                    { 2, 3, 2, 0 },
                    { 3, 5, 4, 1 },
                    { 4, 6, 3, 2 },
                    { 5, 7, 1, 0 },
                    { 6, 7, 6, 0 },
                    { 7, 9, 5, 0 },
                    { 8, 11, 3, 3 },
                    { 9, 12, 4, 4 },
                    { 10, 13, 2, 0 },
                    { 11, 13, 6, 0 },
                    { 12, 15, 3, 2 },
                    { 13, 15, 4, 2 },
                    { 14, 18, 3, 3 },
                    { 15, 22, 3, 10 },
                    { 16, 24, 2, 0 },
                    { 17, 32, 3, 5 },
                    { 18, 32, 2, 0 },
                    { 19, 33, 3, 3 },
                    { 20, 35, 5, 0 },
                    { 21, 35, 4, 2 },
                    { 22, 36, 6, 0 },
                    { 23, 36, 4, 2 },
                    { 24, 39, 5, 0 },
                    { 25, 39, 1, 0 },
                    { 26, 42, 6, 0 },
                    { 27, 42, 5, 0 },
                    { 28, 45, 3, 5 },
                    { 29, 45, 1, 0 },
                    { 30, 49, 2, 0 },
                    { 31, 49, 1, 0 },
                    { 32, 49, 4, 5 }
                });

            migrationBuilder.InsertData(
                table: "StartingCards",
                columns: new[] { "Id", "CardId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 },
                    { 11, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CardPlayer_PlayersId",
                table: "CardPlayer",
                column: "PlayersId");

            migrationBuilder.CreateIndex(
                name: "IX_CardPowers_CardId",
                table: "CardPowers",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_CardPowers_PowerId",
                table: "CardPowers",
                column: "PowerId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_PlayerDataAId",
                table: "Matches",
                column: "PlayerDataAId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_PlayerDataBId",
                table: "Matches",
                column: "PlayerDataBId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayableCard_CardId",
                table: "PlayableCard",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayableCard_MatchPlayerDataId",
                table: "PlayableCard",
                column: "MatchPlayerDataId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayableCard_MatchPlayerDataId1",
                table: "PlayableCard",
                column: "MatchPlayerDataId1");

            migrationBuilder.CreateIndex(
                name: "IX_PlayableCard_MatchPlayerDataId2",
                table: "PlayableCard",
                column: "MatchPlayerDataId2");

            migrationBuilder.CreateIndex(
                name: "IX_PlayableCard_MatchPlayerDataId3",
                table: "PlayableCard",
                column: "MatchPlayerDataId3");

            migrationBuilder.CreateIndex(
                name: "IX_Players_IdentityUserId",
                table: "Players",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SerializedMatchEvent_MatchId",
                table: "SerializedMatchEvent",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_StartingCards_CardId",
                table: "StartingCards",
                column: "CardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CardPlayer");

            migrationBuilder.DropTable(
                name: "CardPowers");

            migrationBuilder.DropTable(
                name: "PlayableCard");

            migrationBuilder.DropTable(
                name: "SerializedMatchEvent");

            migrationBuilder.DropTable(
                name: "StartingCards");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Powers");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "MatchPlayersData");
        }
    }
}

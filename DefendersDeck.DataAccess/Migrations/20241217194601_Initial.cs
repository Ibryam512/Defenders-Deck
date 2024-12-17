using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DefendersDeck.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Turns = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Difficulties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnemiesCount = table.Column<int>(type: "int", nullable: false),
                    CardsPropability = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnemyLevelId = table.Column<int>(type: "int", nullable: false),
                    TowerLevelId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Difficulties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrencyAmount = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnemyLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Health = table.Column<int>(type: "int", nullable: false),
                    Power = table.Column<int>(type: "int", nullable: false),
                    DesignUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DifficultyId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnemyLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnemyLevels_Difficulties_DifficultyId",
                        column: x => x.DifficultyId,
                        principalTable: "Difficulties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TowerLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Health = table.Column<int>(type: "int", nullable: false),
                    DesignUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DifficultyId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TowerLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TowerLevels_Difficulties_DifficultyId",
                        column: x => x.DifficultyId,
                        principalTable: "Difficulties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardUser",
                columns: table => new
                {
                    CardsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardUser", x => new { x.CardsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_CardUser_Cards_CardsId",
                        column: x => x.CardsId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    EnemiesKilled = table.Column<int>(type: "int", nullable: false),
                    DifficultyId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Difficulties_DifficultyId",
                        column: x => x.DifficultyId,
                        principalTable: "Difficulties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardGame",
                columns: table => new
                {
                    CardsId = table.Column<int>(type: "int", nullable: false),
                    GamesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardGame", x => new { x.CardsId, x.GamesId });
                    table.ForeignKey(
                        name: "FK_CardGame_Cards_CardsId",
                        column: x => x.CardsId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardGame_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "Amount", "CreationDate", "Description", "ImageUrl", "Name", "Price", "Turns", "Type" },
                values: new object[,]
                {
                    { 1, 25, new DateTime(2024, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "When this card is placed, a one-time attack is activated, dealing 25 damage.", "", "Fire Arrows", 50, 1, 0 },
                    { 2, 25, new DateTime(2024, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "When this card is placed, for the next three turns, an earthquake occurs, dealing 25 damage.", "", "Earthquake", 70, 3, 0 },
                    { 3, 30, new DateTime(2024, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "When this card is placed, a one-time sound wave appears, dealing 30 damage.", "", "Sound Wave", 60, 1, 0 },
                    { 4, 20, new DateTime(2024, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "When this card is placed, a metal wall is generated, protecting against 20 damage", "", "Fullmetal Alchemy", 80, 1, 1 },
                    { 5, 50, new DateTime(2024, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "When this card is placed, a water shield appears for one turn, absorbing up to 50 attack damage.", "", "Water Shield", 100, 1, 1 },
                    { 6, 30, new DateTime(2024, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "When this card is placed, the tower restores 30 health as a one-time effect.", "", "First Aid", 40, 1, 2 },
                    { 7, 20, new DateTime(2024, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "When this card is placed, it restores 20 health per turn for three turns.", "", "Special Help", 70, 3, 2 },
                    { 8, 100, new DateTime(2024, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "When this card is placed, the tower's entire health is restored as a one-time effect.", "", "Health Potion", 120, 1, 2 },
                    { 9, 0, new DateTime(2024, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "When this card is placed, all dead enemies reappear as shadows and attack the living enemies. Shadows disappear when they kill an enemy.", "", "Shadow Army", 150, 1, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardGame_GamesId",
                table: "CardGame",
                column: "GamesId");

            migrationBuilder.CreateIndex(
                name: "IX_CardUser_UsersId",
                table: "CardUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_EnemyLevels_DifficultyId",
                table: "EnemyLevels",
                column: "DifficultyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_DifficultyId",
                table: "Games",
                column: "DifficultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_UserId",
                table: "Games",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TowerLevels_DifficultyId",
                table: "TowerLevels",
                column: "DifficultyId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardGame");

            migrationBuilder.DropTable(
                name: "CardUser");

            migrationBuilder.DropTable(
                name: "EnemyLevels");

            migrationBuilder.DropTable(
                name: "TowerLevels");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Difficulties");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

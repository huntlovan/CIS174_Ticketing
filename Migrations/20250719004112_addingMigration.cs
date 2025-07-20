using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CIS174_OlympicGame.Migrations
{
    /// <inheritdoc />
    public partial class addingMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameID);
                });

            migrationBuilder.CreateTable(
                name: "SportTypes",
                columns: table => new
                {
                    SportTypeID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportTypes", x => x.SportTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SportTypeID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LogoImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                    table.ForeignKey(
                        name: "FK_Countries_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "GameID");
                    table.ForeignKey(
                        name: "FK_Countries_SportTypes_SportTypeID",
                        column: x => x.SportTypeID,
                        principalTable: "SportTypes",
                        principalColumn: "SportTypeID");
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "GameID", "LogoImage", "Name", "SportTypeID" },
                values: new object[,]
                {
                    { "ari", null, "ARI.png", "Arizona Cardinals", null },
                    { "atl", null, "ATL.png", "Atlanta Falcons", null },
                    { "bal", null, "BAL.png", "Baltimore Ravens", null },
                    { "buf", null, "BUF.png", "Buffalo Bills", null },
                    { "car", null, "CAR.png", "Carolina Panthers", null },
                    { "chi", null, "CHI.png", "Chicago Bears", null },
                    { "cin", null, "CIN.png", "Cincinnati Bengals", null },
                    { "cle", null, "CLE.png", "Cleveland Browns", null },
                    { "dal", null, "DAL.png", "Dallas Cowboys", null },
                    { "den", null, "DEN.png", "Denver Broncos", null },
                    { "det", null, "DET.png", "Detroit Lions", null },
                    { "gb", null, "GB.png", "Green Bay Packers", null },
                    { "hou", null, "HOU.png", "Houston Texans", null },
                    { "ind", null, "IND.png", "Indianapolis Colts", null },
                    { "jax", null, "JAX.png", "Jacksonville Jaguars", null },
                    { "kc", null, "KC.png", "Kansas City Chiefs", null },
                    { "lac", null, "LAC.png", "Los Angeles Chargers", null },
                    { "lar", null, "LAR.png", "Los Angeles Rams", null },
                    { "lv", null, "LV.png", "Las Vegas Raiders", null },
                    { "mia", null, "MIA.png", "Miami Dolphins", null },
                    { "min", null, "MIN.png", "Minnesota Vikings", null },
                    { "ne", null, "NE.png", "New England Patriots", null },
                    { "no", null, "NO.png", "New Orleans Saints", null },
                    { "nyg", null, "NYG.png", "New York Giants", null },
                    { "nyj", null, "NYJ.png", "New York Jets", null },
                    { "phi", null, "PHI.png", "Philadelphia Eagles", null },
                    { "pit", null, "PIT.png", "Pittsburgh Steelers", null },
                    { "sea", null, "SEA.png", "Seattle Seahawks", null },
                    { "sf", null, "SF.png", "San Francisco 49ers", null },
                    { "tb", null, "TB.png", "Tampa Bay Buccaneers", null },
                    { "ten", null, "TEN.png", "Tennessee Titans", null },
                    { "was", null, "WAS.png", "Washington Commanders", null }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameID", "Name" },
                values: new object[,]
                {
                    { "afc", "AFC" },
                    { "nfc", "NFC" }
                });

            migrationBuilder.InsertData(
                table: "SportTypes",
                columns: new[] { "SportTypeID", "Name" },
                values: new object[,]
                {
                    { "east", "East" },
                    { "north", "North" },
                    { "south", "South" },
                    { "west", "West" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_GameID",
                table: "Countries",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_SportTypeID",
                table: "Countries",
                column: "SportTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "SportTypes");
        }
    }
}

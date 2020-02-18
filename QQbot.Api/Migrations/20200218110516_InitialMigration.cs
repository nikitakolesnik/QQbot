using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QQbot.Api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscordId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    PlaysFront = table.Column<bool>(nullable: false),
                    PlaysMid = table.Column<bool>(nullable: false),
                    PlaysBack = table.Column<bool>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    Wins = table.Column<int>(nullable: false),
                    Losses = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lobby",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(nullable: true),
                    TeamNumber = table.Column<int>(nullable: false),
                    Joined = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lobby", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lobby_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    When = table.Column<DateTime>(nullable: false),
                    WinningTeamId = table.Column<int>(nullable: true),
                    LosingTeamId = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_LosingTeamId",
                        column: x => x.LosingTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_WinningTeamId",
                        column: x => x.WinningTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamPlayers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(nullable: true),
                    TeamId = table.Column<int>(nullable: true),
                    RatingBefore = table.Column<int>(nullable: false),
                    RatingAfter = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamPlayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamPlayers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamPlayers_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "DiscordId", "Losses", "Name", "PlaysBack", "PlaysFront", "PlaysMid", "Rating", "Wins" },
                values: new object[,]
                {
                    { 1, 240413827718578177L, 0, "Slam", true, true, false, 0, 0 },
                    { 2, 175325337196953600L, 0, "Yoko", false, true, true, 0, 0 },
                    { 3, 287275232236929026L, 0, "Candy", false, true, true, 0, 0 },
                    { 4, 232147476008796161L, 0, "Godly", false, false, true, 0, 0 },
                    { 5, 416266623847235584L, 0, "Santana", true, false, false, 0, 0 },
                    { 6, 208987498368598016L, 0, "Purif", true, false, true, 0, 0 },
                    { 7, 361620009815900170L, 0, "Chrona", false, true, true, 0, 0 },
                    { 8, 382998762533945344L, 0, "Lisek", true, false, true, 0, 0 },
                    { 9, 277194459576532992L, 0, "Oln", true, false, false, 0, 0 },
                    { 10, 288009866080157697L, 0, "Rainy", true, false, false, 0, 0 },
                    { 11, 465126942656561152L, 0, "Butters", false, true, true, 0, 0 },
                    { 12, 241149128216674305L, 0, "Takida", false, true, false, 0, 0 },
                    { 13, 99492885015048192L, 0, "Jo", false, false, true, 0, 0 },
                    { 14, 221445321530540032L, 0, "Bounty", false, true, true, 0, 0 },
                    { 15, 430796233783640066L, 0, "Cracks", false, true, false, 0, 0 },
                    { 16, 242126086983516160L, 0, "Jonas", true, true, true, 0, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lobby_PlayerId",
                table: "Lobby",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_LosingTeamId",
                table: "Matches",
                column: "LosingTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_WinningTeamId",
                table: "Matches",
                column: "WinningTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_DiscordId",
                table: "Players",
                column: "DiscordId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_Name",
                table: "Players",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamPlayers_PlayerId",
                table: "TeamPlayers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamPlayers_TeamId",
                table: "TeamPlayers",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lobby");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "TeamPlayers");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}

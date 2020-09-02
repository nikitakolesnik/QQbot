using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QQbot.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Submitted = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Discord = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Rating = table.Column<int>(nullable: false)
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
                    PlayerId = table.Column<int>(nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Submitted = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    When = table.Column<DateTime>(nullable: false),
                    WinningTeamId = table.Column<int>(nullable: true),
                    LosingTeamId = table.Column<int>(nullable: true)
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
                    PlayerId = table.Column<int>(nullable: false),
                    TeamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamPlayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamPlayers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamPlayers_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdminHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminId = table.Column<int>(nullable: false),
                    When = table.Column<DateTime>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    SubjectPlayerId = table.Column<int>(nullable: true),
                    SubjectMatchId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminHistory_Players_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminHistory_Matches_SubjectMatchId",
                        column: x => x.SubjectMatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdminHistory_Players_SubjectPlayerId",
                        column: x => x.SubjectPlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Discord", "Name", "Rating", "Status", "Submitted" },
                values: new object[,]
                {
                    { 1, 240413827718578177L, "Slam", 1000, 2, new DateTime(2020, 8, 27, 0, 12, 52, 913, DateTimeKind.Utc).AddTicks(4388) },
                    { 2, 175325337196953600L, "Yoko", 1000, 2, new DateTime(2020, 8, 27, 0, 12, 52, 913, DateTimeKind.Utc).AddTicks(5392) },
                    { 3, 287275232236929026L, "Candyboy", 1000, 2, new DateTime(2020, 8, 27, 0, 12, 52, 913, DateTimeKind.Utc).AddTicks(5415) },
                    { 4, 232147476008796161L, "Godly", 1000, 2, new DateTime(2020, 8, 27, 0, 12, 52, 913, DateTimeKind.Utc).AddTicks(5417) },
                    { 5, 416266623847235584L, "Santana", 1000, 2, new DateTime(2020, 8, 27, 0, 12, 52, 913, DateTimeKind.Utc).AddTicks(5418) },
                    { 6, 208987498368598016L, "Purif", 1000, 2, new DateTime(2020, 8, 27, 0, 12, 52, 913, DateTimeKind.Utc).AddTicks(5422) },
                    { 7, 361620009815900170L, "Chrona", 1000, 2, new DateTime(2020, 8, 27, 0, 12, 52, 913, DateTimeKind.Utc).AddTicks(5423) },
                    { 8, 382998762533945344L, "Lisek", 1000, 2, new DateTime(2020, 8, 27, 0, 12, 52, 913, DateTimeKind.Utc).AddTicks(5425) },
                    { 9, 277194459576532992L, "Oln", 1000, 2, new DateTime(2020, 8, 27, 0, 12, 52, 913, DateTimeKind.Utc).AddTicks(5426) },
                    { 10, 288009866080157697L, "Rainy", 1000, 2, new DateTime(2020, 8, 27, 0, 12, 52, 913, DateTimeKind.Utc).AddTicks(5429) },
                    { 11, 465126942656561152L, "Butters", 1000, 2, new DateTime(2020, 8, 27, 0, 12, 52, 913, DateTimeKind.Utc).AddTicks(5430) },
                    { 12, 241149128216674305L, "Takida", 1000, 2, new DateTime(2020, 8, 27, 0, 12, 52, 913, DateTimeKind.Utc).AddTicks(5432) },
                    { 13, 99492885015048192L, "Jo", 1000, 2, new DateTime(2020, 8, 27, 0, 12, 52, 913, DateTimeKind.Utc).AddTicks(5433) },
                    { 14, 221445321530540032L, "Bounty", 1000, 2, new DateTime(2020, 8, 27, 0, 12, 52, 913, DateTimeKind.Utc).AddTicks(5435) },
                    { 15, 430796233783640066L, "Cracks", 1000, 2, new DateTime(2020, 8, 27, 0, 12, 52, 913, DateTimeKind.Utc).AddTicks(5436) },
                    { 16, 242126086983516160L, "Jonas", 1000, 2, new DateTime(2020, 8, 27, 0, 12, 52, 913, DateTimeKind.Utc).AddTicks(5438) }
                });

            migrationBuilder.InsertData(
                table: "AdminHistory",
                columns: new[] { "Id", "AdminId", "SubjectMatchId", "SubjectPlayerId", "Type", "When" },
                values: new object[,]
                {
                    { 1, 1, null, 1, 2, new DateTime(2020, 8, 27, 0, 12, 52, 914, DateTimeKind.Utc).AddTicks(9254) },
                    { 2, 1, null, 2, 2, new DateTime(2020, 8, 27, 0, 12, 52, 915, DateTimeKind.Utc).AddTicks(1815) },
                    { 3, 1, null, 3, 2, new DateTime(2020, 8, 27, 0, 12, 52, 915, DateTimeKind.Utc).AddTicks(1905) },
                    { 4, 1, null, 4, 2, new DateTime(2020, 8, 27, 0, 12, 52, 915, DateTimeKind.Utc).AddTicks(1985) },
                    { 5, 1, null, 5, 2, new DateTime(2020, 8, 27, 0, 12, 52, 915, DateTimeKind.Utc).AddTicks(2029) },
                    { 6, 1, null, 6, 2, new DateTime(2020, 8, 27, 0, 12, 52, 915, DateTimeKind.Utc).AddTicks(2069) },
                    { 7, 1, null, 7, 2, new DateTime(2020, 8, 27, 0, 12, 52, 915, DateTimeKind.Utc).AddTicks(2107) },
                    { 8, 1, null, 8, 2, new DateTime(2020, 8, 27, 0, 12, 52, 915, DateTimeKind.Utc).AddTicks(2146) },
                    { 9, 1, null, 9, 2, new DateTime(2020, 8, 27, 0, 12, 52, 915, DateTimeKind.Utc).AddTicks(2186) },
                    { 10, 1, null, 10, 2, new DateTime(2020, 8, 27, 0, 12, 52, 915, DateTimeKind.Utc).AddTicks(2225) },
                    { 11, 1, null, 11, 2, new DateTime(2020, 8, 27, 0, 12, 52, 915, DateTimeKind.Utc).AddTicks(2263) },
                    { 12, 1, null, 12, 2, new DateTime(2020, 8, 27, 0, 12, 52, 915, DateTimeKind.Utc).AddTicks(2301) },
                    { 13, 1, null, 13, 2, new DateTime(2020, 8, 27, 0, 12, 52, 915, DateTimeKind.Utc).AddTicks(2339) },
                    { 14, 1, null, 14, 2, new DateTime(2020, 8, 27, 0, 12, 52, 915, DateTimeKind.Utc).AddTicks(2377) },
                    { 15, 1, null, 15, 2, new DateTime(2020, 8, 27, 0, 12, 52, 915, DateTimeKind.Utc).AddTicks(2415) },
                    { 16, 1, null, 16, 2, new DateTime(2020, 8, 27, 0, 12, 52, 915, DateTimeKind.Utc).AddTicks(2480) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminHistory_AdminId",
                table: "AdminHistory",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminHistory_SubjectMatchId",
                table: "AdminHistory",
                column: "SubjectMatchId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminHistory_SubjectPlayerId",
                table: "AdminHistory",
                column: "SubjectPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Lobby_PlayerId",
                table: "Lobby",
                column: "PlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_LosingTeamId",
                table: "Matches",
                column: "LosingTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_WinningTeamId",
                table: "Matches",
                column: "WinningTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_Discord",
                table: "Players",
                column: "Discord",
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
                name: "AdminHistory");

            migrationBuilder.DropTable(
                name: "Lobby");

            migrationBuilder.DropTable(
                name: "TeamPlayers");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}

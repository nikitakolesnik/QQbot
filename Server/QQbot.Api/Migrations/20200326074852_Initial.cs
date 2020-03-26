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
                    TeamId = table.Column<int>(nullable: true),
                    PlayerId = table.Column<int>(nullable: false)
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
                        onDelete: ReferentialAction.Restrict);
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
                    { 1, 240413827718578177L, "Slam", 1000, 2, new DateTime(2020, 3, 26, 7, 48, 52, 522, DateTimeKind.Utc).AddTicks(2524) },
                    { 2, 175325337196953600L, "Yoko", 1000, 2, new DateTime(2020, 3, 26, 7, 48, 52, 522, DateTimeKind.Utc).AddTicks(3488) },
                    { 3, 287275232236929026L, "Candyboy", 1000, 2, new DateTime(2020, 3, 26, 7, 48, 52, 522, DateTimeKind.Utc).AddTicks(3504) },
                    { 4, 232147476008796161L, "Godly", 1000, 2, new DateTime(2020, 3, 26, 7, 48, 52, 522, DateTimeKind.Utc).AddTicks(3506) },
                    { 5, 416266623847235584L, "Santana", 1000, 2, new DateTime(2020, 3, 26, 7, 48, 52, 522, DateTimeKind.Utc).AddTicks(3507) },
                    { 6, 208987498368598016L, "Purif", 1000, 2, new DateTime(2020, 3, 26, 7, 48, 52, 522, DateTimeKind.Utc).AddTicks(3511) },
                    { 7, 361620009815900170L, "Chrona", 1000, 2, new DateTime(2020, 3, 26, 7, 48, 52, 522, DateTimeKind.Utc).AddTicks(3512) },
                    { 8, 382998762533945344L, "Lisek", 1000, 2, new DateTime(2020, 3, 26, 7, 48, 52, 522, DateTimeKind.Utc).AddTicks(3527) },
                    { 9, 277194459576532992L, "Oln", 1000, 2, new DateTime(2020, 3, 26, 7, 48, 52, 522, DateTimeKind.Utc).AddTicks(3528) },
                    { 10, 288009866080157697L, "Rainy", 1000, 2, new DateTime(2020, 3, 26, 7, 48, 52, 522, DateTimeKind.Utc).AddTicks(3531) },
                    { 11, 465126942656561152L, "Butters", 1000, 2, new DateTime(2020, 3, 26, 7, 48, 52, 522, DateTimeKind.Utc).AddTicks(3532) },
                    { 12, 241149128216674305L, "Takida", 1000, 2, new DateTime(2020, 3, 26, 7, 48, 52, 522, DateTimeKind.Utc).AddTicks(3534) },
                    { 13, 99492885015048192L, "Jo", 1000, 2, new DateTime(2020, 3, 26, 7, 48, 52, 522, DateTimeKind.Utc).AddTicks(3535) },
                    { 14, 221445321530540032L, "Bounty", 1000, 2, new DateTime(2020, 3, 26, 7, 48, 52, 522, DateTimeKind.Utc).AddTicks(3536) },
                    { 15, 430796233783640066L, "Cracks", 1000, 2, new DateTime(2020, 3, 26, 7, 48, 52, 522, DateTimeKind.Utc).AddTicks(3538) },
                    { 16, 242126086983516160L, "Jonas", 1000, 2, new DateTime(2020, 3, 26, 7, 48, 52, 522, DateTimeKind.Utc).AddTicks(3539) }
                });

            migrationBuilder.InsertData(
                table: "AdminHistory",
                columns: new[] { "Id", "AdminId", "SubjectMatchId", "SubjectPlayerId", "Type", "When" },
                values: new object[,]
                {
                    { 1, 1, null, 1, 2, new DateTime(2020, 3, 26, 7, 48, 52, 523, DateTimeKind.Utc).AddTicks(6392) },
                    { 2, 1, null, 2, 2, new DateTime(2020, 3, 26, 7, 48, 52, 523, DateTimeKind.Utc).AddTicks(8883) },
                    { 3, 1, null, 3, 2, new DateTime(2020, 3, 26, 7, 48, 52, 523, DateTimeKind.Utc).AddTicks(8970) },
                    { 4, 1, null, 4, 2, new DateTime(2020, 3, 26, 7, 48, 52, 523, DateTimeKind.Utc).AddTicks(9009) },
                    { 5, 1, null, 5, 2, new DateTime(2020, 3, 26, 7, 48, 52, 523, DateTimeKind.Utc).AddTicks(9050) },
                    { 6, 1, null, 6, 2, new DateTime(2020, 3, 26, 7, 48, 52, 523, DateTimeKind.Utc).AddTicks(9088) },
                    { 7, 1, null, 7, 2, new DateTime(2020, 3, 26, 7, 48, 52, 523, DateTimeKind.Utc).AddTicks(9124) },
                    { 8, 1, null, 8, 2, new DateTime(2020, 3, 26, 7, 48, 52, 523, DateTimeKind.Utc).AddTicks(9160) },
                    { 9, 1, null, 9, 2, new DateTime(2020, 3, 26, 7, 48, 52, 523, DateTimeKind.Utc).AddTicks(9198) },
                    { 10, 1, null, 10, 2, new DateTime(2020, 3, 26, 7, 48, 52, 523, DateTimeKind.Utc).AddTicks(9236) },
                    { 11, 1, null, 11, 2, new DateTime(2020, 3, 26, 7, 48, 52, 523, DateTimeKind.Utc).AddTicks(9272) },
                    { 12, 1, null, 12, 2, new DateTime(2020, 3, 26, 7, 48, 52, 523, DateTimeKind.Utc).AddTicks(9308) },
                    { 13, 1, null, 13, 2, new DateTime(2020, 3, 26, 7, 48, 52, 523, DateTimeKind.Utc).AddTicks(9432) },
                    { 14, 1, null, 14, 2, new DateTime(2020, 3, 26, 7, 48, 52, 523, DateTimeKind.Utc).AddTicks(9473) },
                    { 15, 1, null, 15, 2, new DateTime(2020, 3, 26, 7, 48, 52, 523, DateTimeKind.Utc).AddTicks(9508) },
                    { 16, 1, null, 16, 2, new DateTime(2020, 3, 26, 7, 48, 52, 523, DateTimeKind.Utc).AddTicks(9543) }
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

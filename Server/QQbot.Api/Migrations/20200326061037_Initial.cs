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
                    Status = table.Column<int>(nullable: false),
                    ActionDate = table.Column<DateTime>(nullable: false),
                    ActionedById = table.Column<int>(nullable: true),
                    Discord = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Players_ActionedById",
                        column: x => x.ActionedById,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Status = table.Column<int>(nullable: false),
                    ActionDate = table.Column<DateTime>(nullable: false),
                    ActionedById = table.Column<int>(nullable: true),
                    When = table.Column<DateTime>(nullable: false),
                    WinningTeamId = table.Column<int>(nullable: true),
                    LosingTeamId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Players_ActionedById",
                        column: x => x.ActionedById,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "ActionDate", "ActionedById", "Discord", "Name", "Rating", "Status" },
                values: new object[] { 1, new DateTime(2020, 3, 25, 23, 10, 37, 482, DateTimeKind.Local).AddTicks(1955), 1, 240413827718578177L, "Slam", 1000, 2 });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "ActionDate", "ActionedById", "Discord", "Name", "Rating", "Status" },
                values: new object[,]
                {
                    { 2, new DateTime(2020, 3, 25, 23, 10, 37, 485, DateTimeKind.Local).AddTicks(1062), 1, 175325337196953600L, "Yoko", 1000, 2 },
                    { 3, new DateTime(2020, 3, 25, 23, 10, 37, 485, DateTimeKind.Local).AddTicks(1109), 1, 287275232236929026L, "Candy", 1000, 2 },
                    { 4, new DateTime(2020, 3, 25, 23, 10, 37, 485, DateTimeKind.Local).AddTicks(1115), 1, 232147476008796161L, "Godly", 1000, 2 },
                    { 5, new DateTime(2020, 3, 25, 23, 10, 37, 485, DateTimeKind.Local).AddTicks(1118), 1, 416266623847235584L, "Santana", 1000, 2 },
                    { 6, new DateTime(2020, 3, 25, 23, 10, 37, 485, DateTimeKind.Local).AddTicks(1122), 1, 208987498368598016L, "Purif", 1000, 2 },
                    { 7, new DateTime(2020, 3, 25, 23, 10, 37, 485, DateTimeKind.Local).AddTicks(1125), 1, 361620009815900170L, "Chrona", 1000, 2 },
                    { 8, new DateTime(2020, 3, 25, 23, 10, 37, 485, DateTimeKind.Local).AddTicks(1128), 1, 382998762533945344L, "Lisek", 1000, 2 },
                    { 9, new DateTime(2020, 3, 25, 23, 10, 37, 485, DateTimeKind.Local).AddTicks(1132), 1, 277194459576532992L, "Oln", 1000, 2 },
                    { 10, new DateTime(2020, 3, 25, 23, 10, 37, 485, DateTimeKind.Local).AddTicks(1135), 1, 288009866080157697L, "Rainy", 1000, 2 },
                    { 11, new DateTime(2020, 3, 25, 23, 10, 37, 485, DateTimeKind.Local).AddTicks(1139), 1, 465126942656561152L, "Butters", 1000, 2 },
                    { 12, new DateTime(2020, 3, 25, 23, 10, 37, 485, DateTimeKind.Local).AddTicks(1142), 1, 241149128216674305L, "Takida", 1000, 2 },
                    { 13, new DateTime(2020, 3, 25, 23, 10, 37, 485, DateTimeKind.Local).AddTicks(1145), 1, 99492885015048192L, "Jo", 1000, 2 },
                    { 14, new DateTime(2020, 3, 25, 23, 10, 37, 485, DateTimeKind.Local).AddTicks(1149), 1, 221445321530540032L, "Bounty", 1000, 2 },
                    { 15, new DateTime(2020, 3, 25, 23, 10, 37, 485, DateTimeKind.Local).AddTicks(1152), 1, 430796233783640066L, "Cracks", 1000, 2 },
                    { 16, new DateTime(2020, 3, 25, 23, 10, 37, 485, DateTimeKind.Local).AddTicks(1155), 1, 242126086983516160L, "Jonas", 1000, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lobby_PlayerId",
                table: "Lobby",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_ActionedById",
                table: "Matches",
                column: "ActionedById");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_LosingTeamId",
                table: "Matches",
                column: "LosingTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_WinningTeamId",
                table: "Matches",
                column: "WinningTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_ActionedById",
                table: "Players",
                column: "ActionedById");

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

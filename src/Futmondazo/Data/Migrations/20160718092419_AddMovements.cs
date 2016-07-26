using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Futmondazo.Data.Migrations
{
    public partial class AddMovements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerMovements",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    BuyerId = table.Column<string>(nullable: true),
                    ChampionshipId = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    NumberOfBids = table.Column<int>(nullable: false),
                    PlayerId = table.Column<string>(nullable: true),
                    PlayerName = table.Column<string>(nullable: true),
                    PlayerValue = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    SellerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerMovements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerMovements_Teams_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerMovements_Teams_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<string>(
                name: "ChampionshipId",
                table: "Teams",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMovements_BuyerId",
                table: "PlayerMovements",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMovements_SellerId",
                table: "PlayerMovements",
                column: "SellerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChampionshipId",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "PlayerMovements");
        }
    }
}

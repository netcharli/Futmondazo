using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Futmondazo.Data.Migrations
{
    public partial class AddChampionship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Championship",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Championship", x => x.Id);
                });


            migrationBuilder.AddColumn<string>(
                name: "ChampionshipId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ChampionshipId",
                table: "Teams",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_ChampionshipId",
                table: "Teams",
                column: "ChampionshipId");

            migrationBuilder.AlterColumn<string>(
                name: "ChampionshipId",
                table: "PlayerMovements",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMovements_ChampionshipId",
                table: "PlayerMovements",
                column: "ChampionshipId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ChampionshipId",
                table: "AspNetUsers",
                column: "ChampionshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Championship_ChampionshipId",
                table: "AspNetUsers",
                column: "ChampionshipId",
                principalTable: "Championship",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerMovements_Championship_ChampionshipId",
                table: "PlayerMovements",
                column: "ChampionshipId",
                principalTable: "Championship",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Championship_ChampionshipId",
                table: "Teams",
                column: "ChampionshipId",
                principalTable: "Championship",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Championship_ChampionshipId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerMovements_Championship_ChampionshipId",
                table: "PlayerMovements");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Championship_ChampionshipId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_ChampionshipId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_PlayerMovements_ChampionshipId",
                table: "PlayerMovements");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ChampionshipId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ChampionshipId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Championship");

            migrationBuilder.AlterColumn<string>(
                name: "ChampionshipId",
                table: "Teams",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ChampionshipId",
                table: "PlayerMovements",
                nullable: true);
        }
    }
}

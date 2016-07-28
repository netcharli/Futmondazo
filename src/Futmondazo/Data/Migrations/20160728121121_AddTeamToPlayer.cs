using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Futmondazo.Data.Migrations
{
    public partial class AddTeamToPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeamId",
                table: "Player",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Player_TeamId",
                table: "Player",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Teams_TeamId",
                table: "Player",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Teams_TeamId",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Player_TeamId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Player");
        }
    }
}

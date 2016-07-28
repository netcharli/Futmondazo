using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Futmondazo.Data.Migrations
{
    public partial class ModifyPlayers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Teams_TeamId",
                table: "Player");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_AspNetUsers_UserId",
                table: "Player");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerHistory_Player_PlayerId",
                table: "PlayerHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerHistory",
                table: "PlayerHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Player",
                table: "Player");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerHistories",
                table: "PlayerHistory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Players",
                table: "Player",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Player",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_AspNetUsers_UserId",
                table: "Player",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerHistories_Players_PlayerId",
                table: "PlayerHistory",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameIndex(
                name: "IX_PlayerHistory_PlayerId",
                table: "PlayerHistory",
                newName: "IX_PlayerHistories_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Player_UserId",
                table: "Player",
                newName: "IX_Players_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Player_TeamId",
                table: "Player",
                newName: "IX_Players_TeamId");

            migrationBuilder.RenameTable(
                name: "PlayerHistory",
                newName: "PlayerHistories");

            migrationBuilder.RenameTable(
                name: "Player",
                newName: "Players");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_AspNetUsers_UserId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerHistories_Players_PlayerId",
                table: "PlayerHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerHistories",
                table: "PlayerHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Players",
                table: "Players");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerHistory",
                table: "PlayerHistories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Player",
                table: "Players",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Teams_TeamId",
                table: "Players",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_AspNetUsers_UserId",
                table: "Players",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerHistory_Player_PlayerId",
                table: "PlayerHistories",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameIndex(
                name: "IX_PlayerHistories_PlayerId",
                table: "PlayerHistories",
                newName: "IX_PlayerHistory_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Players_UserId",
                table: "Players",
                newName: "IX_Player_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                newName: "IX_Player_TeamId");

            migrationBuilder.RenameTable(
                name: "PlayerHistories",
                newName: "PlayerHistory");

            migrationBuilder.RenameTable(
                name: "Players",
                newName: "Player");
        }
    }
}

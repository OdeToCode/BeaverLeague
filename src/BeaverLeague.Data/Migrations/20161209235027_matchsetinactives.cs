using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeaverLeague.Data.Migrations
{
    public partial class matchsetinactives : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MatchSetId",
                table: "Golfers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Golfers_MatchSetId",
                table: "Golfers",
                column: "MatchSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Golfers_MatchSets_MatchSetId",
                table: "Golfers",
                column: "MatchSetId",
                principalTable: "MatchSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Golfers_MatchSets_MatchSetId",
                table: "Golfers");

            migrationBuilder.DropIndex(
                name: "IX_Golfers_MatchSetId",
                table: "Golfers");

            migrationBuilder.DropColumn(
                name: "MatchSetId",
                table: "Golfers");
        }
    }
}

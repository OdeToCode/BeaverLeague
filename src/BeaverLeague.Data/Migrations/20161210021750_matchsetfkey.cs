using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeaverLeague.Data.Migrations
{
    public partial class matchsetfkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MatchSetInactiveGolfer_GolferId",
                table: "MatchSetInactiveGolfer",
                column: "GolferId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchSetInactiveGolfer_Golfers_GolferId",
                table: "MatchSetInactiveGolfer",
                column: "GolferId",
                principalTable: "Golfers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchSetInactiveGolfer_Golfers_GolferId",
                table: "MatchSetInactiveGolfer");

            migrationBuilder.DropIndex(
                name: "IX_MatchSetInactiveGolfer_GolferId",
                table: "MatchSetInactiveGolfer");
        }
    }
}

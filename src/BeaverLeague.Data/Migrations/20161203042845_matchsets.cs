using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeaverLeague.Data.Migrations
{
    public partial class matchsets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_Golfers_GolferAId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Golfers_GolferBId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_MatchSet_MatchSetId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchSet_Seasons_SeasonId",
                table: "MatchSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MatchSet",
                table: "MatchSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Match",
                table: "Match");

            migrationBuilder.RenameTable(
                name: "MatchSet",
                newName: "MatchSets");

            migrationBuilder.RenameTable(
                name: "Match",
                newName: "Matches");

            migrationBuilder.RenameIndex(
                name: "IX_MatchSet_SeasonId",
                table: "MatchSets",
                newName: "IX_MatchSets_SeasonId");

            migrationBuilder.RenameIndex(
                name: "IX_Match_MatchSetId",
                table: "Matches",
                newName: "IX_Matches_MatchSetId");

            migrationBuilder.RenameIndex(
                name: "IX_Match_GolferBId",
                table: "Matches",
                newName: "IX_Matches_GolferBId");

            migrationBuilder.RenameIndex(
                name: "IX_Match_GolferAId",
                table: "Matches",
                newName: "IX_Matches_GolferAId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MatchSets",
                table: "MatchSets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Matches",
                table: "Matches",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Golfers_GolferAId",
                table: "Matches",
                column: "GolferAId",
                principalTable: "Golfers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Golfers_GolferBId",
                table: "Matches",
                column: "GolferBId",
                principalTable: "Golfers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_MatchSets_MatchSetId",
                table: "Matches",
                column: "MatchSetId",
                principalTable: "MatchSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchSets_Seasons_SeasonId",
                table: "MatchSets",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Golfers_GolferAId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Golfers_GolferBId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_MatchSets_MatchSetId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchSets_Seasons_SeasonId",
                table: "MatchSets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MatchSets",
                table: "MatchSets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Matches",
                table: "Matches");

            migrationBuilder.RenameTable(
                name: "MatchSets",
                newName: "MatchSet");

            migrationBuilder.RenameTable(
                name: "Matches",
                newName: "Match");

            migrationBuilder.RenameIndex(
                name: "IX_MatchSets_SeasonId",
                table: "MatchSet",
                newName: "IX_MatchSet_SeasonId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_MatchSetId",
                table: "Match",
                newName: "IX_Match_MatchSetId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_GolferBId",
                table: "Match",
                newName: "IX_Match_GolferBId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_GolferAId",
                table: "Match",
                newName: "IX_Match_GolferAId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MatchSet",
                table: "MatchSet",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Match",
                table: "Match",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Golfers_GolferAId",
                table: "Match",
                column: "GolferAId",
                principalTable: "Golfers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Golfers_GolferBId",
                table: "Match",
                column: "GolferBId",
                principalTable: "Golfers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_MatchSet_MatchSetId",
                table: "Match",
                column: "MatchSetId",
                principalTable: "MatchSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchSet_Seasons_SeasonId",
                table: "MatchSet",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BeaverLeague.Data.Migrations
{
    public partial class matchsetfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "MatchSetInactiveGolfer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GolferId = table.Column<int>(nullable: false),
                    MatchSetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchSetInactiveGolfer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchSetInactiveGolfer_MatchSets_MatchSetId",
                        column: x => x.MatchSetId,
                        principalTable: "MatchSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchSetInactiveGolfer_MatchSetId",
                table: "MatchSetInactiveGolfer",
                column: "MatchSetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchSetInactiveGolfer");

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
    }
}

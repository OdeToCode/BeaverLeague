using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BeaverLeague.Data.Migrations
{
    public partial class matches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GolferAId = table.Column<int>(nullable: true),
                    GolferBId = table.Column<int>(nullable: true),
                    MatchSetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_Golfers_GolferAId",
                        column: x => x.GolferAId,
                        principalTable: "Golfers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_Golfers_GolferBId",
                        column: x => x.GolferBId,
                        principalTable: "Golfers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_MatchSet_MatchSetId",
                        column: x => x.MatchSetId,
                        principalTable: "MatchSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Match_GolferAId",
                table: "Match",
                column: "GolferAId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_GolferBId",
                table: "Match",
                column: "GolferBId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_MatchSetId",
                table: "Match",
                column: "MatchSetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Match");
        }
    }
}

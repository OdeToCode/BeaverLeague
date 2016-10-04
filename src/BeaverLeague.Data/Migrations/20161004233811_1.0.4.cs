using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeaverLeague.Data.Migrations
{
    public partial class _104 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Golfers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_Name",
                table: "Seasons",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Seasons_Name",
                table: "Seasons");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Golfers");
        }
    }
}

﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BeaverLeague.Data.Migrations
{
    public partial class v1000 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Golfers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 80, nullable: false),
                    Handicap = table.Column<float>(nullable: false),
                    LastName = table.Column<string>(maxLength: 80, nullable: false),
                    MembershipId = table.Column<int>(nullable: false),
                    PasswordHash = table.Column<string>(maxLength: 255, nullable: true),
                    Username = table.Column<string>(maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Golfers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Golfers_MembershipId",
                table: "Golfers",
                column: "MembershipId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Golfers_Username",
                table: "Golfers",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Golfers");
        }
    }
}

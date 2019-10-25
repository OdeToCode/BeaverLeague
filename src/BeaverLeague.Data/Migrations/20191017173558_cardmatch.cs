using Microsoft.EntityFrameworkCore.Migrations;

namespace BeaverLeague.Data.Migrations
{
    public partial class cardmatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder is null) throw new System.ArgumentNullException(nameof(migrationBuilder));

            migrationBuilder.AddColumn<bool>(
                name: "IsCardMatch",
                table: "Golfers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder is null) throw new System.ArgumentNullException(nameof(migrationBuilder));

            migrationBuilder.DropColumn(
                name: "IsCardMatch",
                table: "Golfers");
        }
    }
}

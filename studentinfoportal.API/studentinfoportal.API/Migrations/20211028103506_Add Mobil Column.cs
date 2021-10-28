using Microsoft.EntityFrameworkCore.Migrations;

namespace studentinfoportal.API.Migrations
{
    public partial class AddMobilColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "Student",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "Student");
        }
    }
}

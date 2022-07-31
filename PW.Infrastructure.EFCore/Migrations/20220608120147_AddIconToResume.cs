using Microsoft.EntityFrameworkCore.Migrations;

namespace PW.Infrastructure.EFCore.Migrations
{
    public partial class AddIconToResume : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Resumes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Resumes");
        }
    }
}

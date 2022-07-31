using Microsoft.EntityFrameworkCore.Migrations;

namespace UM.Infrastructure.EFCore.Migrations
{
    public partial class user14001207 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IDCardIMG",
                table: "Tbl_Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IDCardIMG",
                table: "Tbl_Users",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);
        }
    }
}

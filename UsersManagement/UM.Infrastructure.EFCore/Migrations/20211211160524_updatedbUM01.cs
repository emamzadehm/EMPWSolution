using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UM.Infrastructure.EFCore.Migrations
{
    public partial class updatedbUM01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Role_Permission");

            migrationBuilder.DropTable(
                name: "Tbl_Permissions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Permissions",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Permissions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tbl_Permissions_Tbl_Permissions_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Tbl_Permissions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Role_Permission",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PermissionID = table.Column<long>(type: "bigint", nullable: false),
                    RoleID = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Role_Permission", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tbl_Role_Permission_Tbl_Permissions_PermissionID",
                        column: x => x.PermissionID,
                        principalTable: "Tbl_Permissions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Role_Permission_Tbl_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Tbl_Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Permissions_ParentId",
                table: "Tbl_Permissions",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Role_Permission_PermissionID",
                table: "Tbl_Role_Permission",
                column: "PermissionID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Role_Permission_RoleID",
                table: "Tbl_Role_Permission",
                column: "RoleID");
        }
    }
}

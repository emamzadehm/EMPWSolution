using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UM.Infrastructure.EFCore.Migrations
{
    public partial class updatedbUM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Permissions",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "Tbl_Roles",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Users",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Sex = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IMG = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDCardIMG = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Role_Permission",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleID = table.Column<long>(type: "bigint", nullable: false),
                    PermissionID = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Tbl_Users_Roles",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<long>(type: "bigint", nullable: false),
                    RoleID = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Users_Roles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tbl_Users_Roles_Tbl_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Tbl_Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Users_Roles_Tbl_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Tbl_Users",
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

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Users_Roles_RoleID",
                table: "Tbl_Users_Roles",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Users_Roles_UserID",
                table: "Tbl_Users_Roles",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Role_Permission");

            migrationBuilder.DropTable(
                name: "Tbl_Users_Roles");

            migrationBuilder.DropTable(
                name: "Tbl_Permissions");

            migrationBuilder.DropTable(
                name: "Tbl_Roles");

            migrationBuilder.DropTable(
                name: "Tbl_Users");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sister.Migrations
{
    public partial class AddRoleInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoleInfos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(16)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleInfos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleInfos");
        }
    }
}

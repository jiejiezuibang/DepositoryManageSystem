using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sister.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepartmentInfos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    DepartmentName = table.Column<string>(type: "nvarchar(16)", nullable: true),
                    LeaderId = table.Column<string>(type: "varchar(36)", nullable: true),
                    ParentId = table.Column<string>(type: "varchar(36)", nullable: true),
                    CreateTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteTime = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    Account = table.Column<string>(type: "varchar(16)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(16)", nullable: true),
                    PhoneNum = table.Column<string>(type: "varchar(16)", nullable: true),
                    Email = table.Column<string>(type: "varchar(32)", nullable: true),
                    DepartmentId = table.Column<string>(type: "varchar(36)", nullable: true),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    PassWord = table.Column<string>(type: "varchar(32)", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentInfos");

            migrationBuilder.DropTable(
                name: "UserInfos");
        }
    }
}

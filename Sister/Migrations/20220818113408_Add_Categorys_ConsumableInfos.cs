using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sister.Migrations
{
    public partial class Add_Categorys_ConsumableInfos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(16)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConsumableInfos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    CategoryId = table.Column<string>(type: "varchar(36)", nullable: true),
                    ConsumableName = table.Column<string>(type: "nvarchar(16)", nullable: true),
                    Specification = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    Num = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(8)", nullable: true),
                    Money = table.Column<double>(type: "float", nullable: false),
                    WarningNum = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumableInfos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "ConsumableInfos");
        }
    }
}

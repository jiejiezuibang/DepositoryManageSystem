using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sister.Migrations
{
    public partial class add_workFlow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkFlow_Instances",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    ModelId = table.Column<string>(type: "varchar(36)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(64)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(64)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<string>(type: "varchar(36)", nullable: true),
                    OutNum = table.Column<int>(type: "int", nullable: false),
                    OutGoodsId = table.Column<string>(type: "varchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkFlow_Instances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkFlow_InstanceSteps",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    InstanceId = table.Column<string>(type: "varchar(36)", nullable: true),
                    ReviewerId = table.Column<string>(type: "varchar(36)", nullable: true),
                    ReviewReason = table.Column<string>(type: "nvarchar(64)", nullable: true),
                    ReviewStatus = table.Column<int>(type: "int", nullable: false),
                    ReviewTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BeforeStepId = table.Column<string>(type: "varchar(36)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkFlow_InstanceSteps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkFlow_Models",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(64)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkFlow_Models", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkFlow_Instances");

            migrationBuilder.DropTable(
                name: "WorkFlow_InstanceSteps");

            migrationBuilder.DropTable(
                name: "WorkFlow_Models");
        }
    }
}

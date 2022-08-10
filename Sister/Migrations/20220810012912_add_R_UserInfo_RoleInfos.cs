using Microsoft.EntityFrameworkCore.Migrations;

namespace Sister.Migrations
{
    public partial class add_R_UserInfo_RoleInfos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "R_UserInfo_RoleInfos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    UserId = table.Column<string>(type: "varchar(36)", nullable: true),
                    RoleId = table.Column<string>(type: "varchar(36)", nullable: true),
                    CreateTime = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_UserInfo_RoleInfos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "R_UserInfo_RoleInfos");
        }
    }
}

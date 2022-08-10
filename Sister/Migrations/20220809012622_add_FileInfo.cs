using Microsoft.EntityFrameworkCore.Migrations;

namespace Sister.Migrations
{
    public partial class add_FileInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileInfos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    RelationId = table.Column<string>(type: "varchar(36)", nullable: true),
                    OldFileName = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    NewFileName = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    Extension = table.Column<string>(type: "varchar(12)", nullable: true),
                    Length = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileInfos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileInfos");
        }
    }
}

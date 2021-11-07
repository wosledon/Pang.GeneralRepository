using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pang.GeneralRepository.Web.Migrations
{
    public partial class init_sqlite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreateUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModifyUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EnableMark = table.Column<bool>(type: "INTEGER", nullable: false),
                    DeleteMark = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}

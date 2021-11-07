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

            migrationBuilder.CreateTable(
                name: "UserItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreateUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModifyUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EnableMark = table.Column<bool>(type: "INTEGER", nullable: false),
                    DeleteMark = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserItem_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserItem_UserId",
                table: "UserItem",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserItem");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}

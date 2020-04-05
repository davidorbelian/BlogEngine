using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogEngine.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Articles",
                table => new
                {
                    Id = table.Column<string>(),
                    CreateTime = table.Column<DateTime>(),
                    UpdateTime = table.Column<DateTime>(),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Articles", x => x.Id); });

            migrationBuilder.CreateTable(
                "Comments",
                table => new
                {
                    Id = table.Column<string>(),
                    CreateTime = table.Column<DateTime>(),
                    UpdateTime = table.Column<DateTime>(),
                    Author = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    ArticleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        "FK_Comments_Articles_ArticleId",
                        x => x.ArticleId,
                        "Articles",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_Comments_ArticleId",
                "Comments",
                "ArticleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Comments");

            migrationBuilder.DropTable(
                "Articles");
        }
    }
}
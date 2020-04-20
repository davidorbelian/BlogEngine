using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogEngine.Infrastructure.Migrations
{
    public partial class Hashtags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "HashTags",
                table => new
                {
                    Id = table.Column<string>(),
                    CreateTime = table.Column<DateTime>(),
                    UpdateTime = table.Column<DateTime>()
                },
                constraints: table => { table.PrimaryKey("PK_HashTags", x => x.Id); });

            migrationBuilder.CreateTable(
                "ArticleHashTag",
                table => new
                {
                    ArticleId = table.Column<string>(),
                    HashTagId = table.Column<string>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleHashTag", x => new {x.ArticleId, x.HashTagId});
                    table.ForeignKey(
                        "FK_ArticleHashTag_Articles_ArticleId",
                        x => x.ArticleId,
                        "Articles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_ArticleHashTag_HashTags_HashTagId",
                        x => x.HashTagId,
                        "HashTags",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_ArticleHashTag_HashTagId",
                "ArticleHashTag",
                "HashTagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "ArticleHashTag");

            migrationBuilder.DropTable(
                "HashTags");
        }
    }
}
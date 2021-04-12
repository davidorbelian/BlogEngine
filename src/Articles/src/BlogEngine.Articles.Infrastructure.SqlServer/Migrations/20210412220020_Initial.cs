using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogEngine.Articles.Infrastructure.SqlServer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Articles",
                table => new
                {
                    Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                    Title = table.Column<string>("nvarchar(max)", nullable: true),
                    Content = table.Column<string>("nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTime>("datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    UpdateTime = table.Column<DateTime>("datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table => { table.PrimaryKey("PK_Articles", x => x.Id); });

            migrationBuilder.CreateTable(
                "Comment",
                table => new
                {
                    Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                    Author = table.Column<string>("nvarchar(max)", nullable: true),
                    Content = table.Column<string>("nvarchar(max)", nullable: true),
                    ArticleId = table.Column<Guid>("uniqueidentifier", nullable: false),
                    CreateTime = table.Column<DateTime>("datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>("datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        "FK_Comment_Articles_ArticleId",
                        x => x.ArticleId,
                        "Articles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "HashTag",
                table => new
                {
                    Id = table.Column<string>("nvarchar(450)", nullable: false),
                    ArticleId = table.Column<Guid>("uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HashTag", x => new {x.ArticleId, x.Id});
                    table.ForeignKey(
                        "FK_HashTag_Articles_ArticleId",
                        x => x.ArticleId,
                        "Articles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_Articles_CreateTime",
                "Articles",
                "CreateTime");

            migrationBuilder.CreateIndex(
                "IX_Articles_UpdateTime",
                "Articles",
                "UpdateTime");

            migrationBuilder.CreateIndex(
                "IX_Comment_ArticleId",
                "Comment",
                "ArticleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Comment");

            migrationBuilder.DropTable(
                "HashTag");

            migrationBuilder.DropTable(
                "Articles");
        }
    }
}
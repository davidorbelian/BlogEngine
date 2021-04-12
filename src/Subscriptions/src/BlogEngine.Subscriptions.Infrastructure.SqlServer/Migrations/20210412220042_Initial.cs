using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogEngine.Subscriptions.Infrastructure.SqlServer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Subscriptions",
                table => new
                {
                    Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                    Email = table.Column<string>("nvarchar(450)", nullable: true),
                    CreateTime = table.Column<DateTime>("datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    UpdateTime = table.Column<DateTime>("datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table => { table.PrimaryKey("PK_Subscriptions", x => x.Id); });

            migrationBuilder.CreateTable(
                "HashTag",
                table => new
                {
                    Id = table.Column<string>("nvarchar(450)", nullable: false),
                    SubscriptionId = table.Column<Guid>("uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HashTag", x => new {x.SubscriptionId, x.Id});
                    table.ForeignKey(
                        "FK_HashTag_Subscriptions_SubscriptionId",
                        x => x.SubscriptionId,
                        "Subscriptions",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_Subscriptions_CreateTime",
                "Subscriptions",
                "CreateTime");

            migrationBuilder.CreateIndex(
                "IX_Subscriptions_Email",
                "Subscriptions",
                "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                "IX_Subscriptions_UpdateTime",
                "Subscriptions",
                "UpdateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "HashTag");

            migrationBuilder.DropTable(
                "Subscriptions");
        }
    }
}
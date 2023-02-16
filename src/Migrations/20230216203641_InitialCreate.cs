using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "forum_users",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    username = table.Column<string>(type: "TEXT", nullable: true),
                    password = table.Column<string>(type: "TEXT", nullable: true),
                    isAdmin = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_forum_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "forum_comments",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    content = table.Column<string>(type: "TEXT", nullable: true),
                    created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    authorid = table.Column<int>(type: "INTEGER", nullable: true),
                    postId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_forum_comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_forum_comments_forum_users_authorid",
                        column: x => x.authorid,
                        principalTable: "forum_users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "forum_posts",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(type: "TEXT", nullable: true),
                    content = table.Column<string>(type: "TEXT", nullable: true),
                    created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    authorid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_forum_posts", x => x.id);
                    table.ForeignKey(
                        name: "FK_forum_posts_forum_users_authorid",
                        column: x => x.authorid,
                        principalTable: "forum_users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "forum_likes",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    authorid = table.Column<int>(type: "INTEGER", nullable: true),
                    postid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_forum_likes", x => x.id);
                    table.ForeignKey(
                        name: "FK_forum_likes_forum_posts_postid",
                        column: x => x.postid,
                        principalTable: "forum_posts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_forum_likes_forum_users_authorid",
                        column: x => x.authorid,
                        principalTable: "forum_users",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "forum_users",
                columns: new[] { "id", "isAdmin", "password", "username" },
                values: new object[,]
                {
                    { 1, true, "admin", "admin" },
                    { 2, false, "user", "user" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_forum_comments_authorid",
                table: "forum_comments",
                column: "authorid");

            migrationBuilder.CreateIndex(
                name: "IX_forum_likes_authorid",
                table: "forum_likes",
                column: "authorid");

            migrationBuilder.CreateIndex(
                name: "IX_forum_likes_postid",
                table: "forum_likes",
                column: "postid");

            migrationBuilder.CreateIndex(
                name: "IX_forum_posts_authorid",
                table: "forum_posts",
                column: "authorid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "forum_comments");

            migrationBuilder.DropTable(
                name: "forum_likes");

            migrationBuilder.DropTable(
                name: "forum_posts");

            migrationBuilder.DropTable(
                name: "forum_users");
        }
    }
}

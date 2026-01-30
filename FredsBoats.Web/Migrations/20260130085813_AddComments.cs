using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FredsBoats.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "comment",
                columns: table => new
                {
                    commentid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    content = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    author = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    createdat = table.Column<DateTime>(type: "TEXT", nullable: false),
                    fkcategoryid = table.Column<int>(type: "INTEGER", nullable: false),
                    fkboatid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment", x => x.commentid);
                    table.ForeignKey(
                        name: "FK_comment_boat_fkboatid",
                        column: x => x.fkboatid,
                        principalTable: "boat",
                        principalColumn: "boatid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_comment_fkboatid",
                table: "comment",
                column: "fkboatid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comment");
        }
    }
}

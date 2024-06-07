using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinterWhispers.Migrations
{
    /// <inheritdoc />
    public partial class addedcomment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inbox");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.CreateTable(
                name: "Inbox",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateSent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inbox", x => x.Id);
                });
        }
    }
}

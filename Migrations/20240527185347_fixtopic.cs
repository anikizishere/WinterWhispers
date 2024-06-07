using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinterWhispers.Migrations
{
    /// <inheritdoc />
    public partial class fixtopic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Topic",
                table: "Forum");

            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "Forum",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Forum_TopicId",
                table: "Forum",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Forum_Topic_TopicId",
                table: "Forum",
                column: "TopicId",
                principalTable: "Topic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forum_Topic_TopicId",
                table: "Forum");

            migrationBuilder.DropTable(
                name: "Topic");

            migrationBuilder.DropIndex(
                name: "IX_Forum_TopicId",
                table: "Forum");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "Forum");

            migrationBuilder.AddColumn<string>(
                name: "Topic",
                table: "Forum",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

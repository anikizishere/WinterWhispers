using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinterWhispers.Migrations
{
    /// <inheritdoc />
    public partial class fixformdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forum_Topic_TopicId",
                table: "Forum");

            migrationBuilder.AlterColumn<int>(
                name: "TopicId",
                table: "Forum",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Forum_Topic_TopicId",
                table: "Forum",
                column: "TopicId",
                principalTable: "Topic",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forum_Topic_TopicId",
                table: "Forum");

            migrationBuilder.AlterColumn<int>(
                name: "TopicId",
                table: "Forum",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Forum_Topic_TopicId",
                table: "Forum",
                column: "TopicId",
                principalTable: "Topic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

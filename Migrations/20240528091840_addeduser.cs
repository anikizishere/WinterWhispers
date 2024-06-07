using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinterWhispers.Migrations
{
    /// <inheritdoc />
    public partial class addeduser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Forum",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Forum_UserId",
                table: "Forum",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Forum_AspNetUsers_UserId",
                table: "Forum",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forum_AspNetUsers_UserId",
                table: "Forum");

            migrationBuilder.DropIndex(
                name: "IX_Forum_UserId",
                table: "Forum");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Forum",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}

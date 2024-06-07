using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinterWhispers.Migrations
{
    /// <inheritdoc />
    public partial class fixedinbox : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Inbox_AspNetUsers_ReceiverId",
            //    table: "Inbox");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Inbox_AspNetUsers_SenderId",
            //    table: "Inbox");

            //migrationBuilder.DropIndex(
            //    name: "IX_Inbox_ReceiverId",
            //    table: "Inbox");

            //migrationBuilder.DropIndex(
            //    name: "IX_Inbox_SenderId",
            //    table: "Inbox");

            //migrationBuilder.AlterColumn<string>(
            //    name: "SenderId",
            //    table: "Inbox",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(450)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "ReceiverId",
            //    table: "Inbox",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<string>(
            //    name: "SenderId",
            //    table: "Inbox",
            //    type: "nvarchar(450)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "ReceiverId",
            //    table: "Inbox",
            //    type: "nvarchar(450)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Inbox_ReceiverId",
            //    table: "Inbox",
            //    column: "ReceiverId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Inbox_SenderId",
            //    table: "Inbox",
            //    column: "SenderId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Inbox_AspNetUsers_ReceiverId",
            //    table: "Inbox",
            //    column: "ReceiverId",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Inbox_AspNetUsers_SenderId",
            //    table: "Inbox",
            //    column: "SenderId",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}

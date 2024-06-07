using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinterWhispers.Migrations
{
    /// <inheritdoc />
    public partial class addedinbox : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Inbox",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        SenderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ReceiverId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        DateSent = table.Column<DateTime>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Inbox", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Inbox_AspNetUsers_ReceiverId",
            //            column: x => x.ReceiverId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Inbox_AspNetUsers_SenderId",
            //            column: x => x.SenderId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Inbox_ReceiverId",
            //    table: "Inbox",
            //    column: "ReceiverId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Inbox_SenderId",
            //    table: "Inbox",
            //    column: "SenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Inbox");
        }
    }
}

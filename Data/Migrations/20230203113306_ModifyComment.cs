using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OfficialProject3.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifyComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            //migrationBuilder.AlterColumn<int>(
            //    name: "ItemId",
            //    table: "Comment",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "Content",
            //    table: "Comment",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "",
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CommentDate",
                table: "Comment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            //migrationBuilder.CreateIndex(
            //    name: "IX_Comment_ItemId",
            //    table: "Comment",
            //    column: "ItemId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Comment_Item_ItemId",
            //    table: "Comment",
            //    column: "ItemId",
            //    principalTable: "Item",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Comment_Item_ItemId",
            //    table: "Comment");

            //migrationBuilder.DropIndex(
            //    name: "IX_Comment_ItemId",
            //    table: "Comment");

            //migrationBuilder.DropColumn(
            //    name: "CommentDate",
            //    table: "Comment");

            //migrationBuilder.AlterColumn<string>(
            //    name: "ItemId",
            //    table: "Comment",
            //    type: "nvarchar(max)",
            //    nullable: true,
            //    oldClrType: typeof(int),
            //    oldType: "int");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Content",
            //    table: "Comment",
            //    type: "nvarchar(max)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");
        }
    }
}

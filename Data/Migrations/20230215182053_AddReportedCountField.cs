using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OfficialProject3.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddReportedCountField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReportedCount",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportedCount",
                table: "AspNetUsers");
        }
    }
}

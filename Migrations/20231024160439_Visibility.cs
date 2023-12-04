using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorPagesDreams.Migrations
{
    /// <inheritdoc />
    public partial class Visibility : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Visibility",
                table: "Dream",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Visibility",
                table: "Dream");
        }
    }
}

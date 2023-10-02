using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Angular.ASP_SearchPosition.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUrlToSearchResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "SearchResults",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "SearchResults");
        }
    }
}

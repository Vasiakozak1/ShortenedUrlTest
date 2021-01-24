using Microsoft.EntityFrameworkCore.Migrations;

namespace UrlShortener.Migrations
{
    public partial class UpdatedIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UrlEntries_Key",
                table: "UrlEntries");

            migrationBuilder.CreateIndex(
                name: "IX_UrlEntries_ShortUrl",
                table: "UrlEntries",
                column: "ShortUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UrlEntries_ShortUrl",
                table: "UrlEntries");

            migrationBuilder.CreateIndex(
                name: "IX_UrlEntries_Key",
                table: "UrlEntries",
                column: "Key");
        }
    }
}

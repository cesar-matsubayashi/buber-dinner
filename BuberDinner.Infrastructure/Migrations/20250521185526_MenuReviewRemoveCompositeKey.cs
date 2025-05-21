using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuberDinner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MenuReviewRemoveCompositeKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuReviews",
                table: "MenuReviews");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuReviews",
                table: "MenuReviews",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuReviews",
                table: "MenuReviews");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuReviews",
                table: "MenuReviews",
                columns: new[] { "Id", "GuestId", "DinnerId" });
        }
    }
}

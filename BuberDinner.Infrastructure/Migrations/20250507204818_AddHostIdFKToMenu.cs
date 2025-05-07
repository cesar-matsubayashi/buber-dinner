using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuberDinner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddHostIdFKToMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Menus_HostId",
                table: "Menus",
                column: "HostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Hosts_HostId",
                table: "Menus",
                column: "HostId",
                principalTable: "Hosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Hosts_HostId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_HostId",
                table: "Menus");
        }
    }
}

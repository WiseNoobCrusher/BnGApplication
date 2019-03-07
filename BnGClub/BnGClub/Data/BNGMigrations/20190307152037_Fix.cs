using Microsoft.EntityFrameworkCore.Migrations;

namespace BnGClub.Data.BNGMigrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_userEmail",
                schema: "BNG",
                table: "Users",
                column: "userEmail",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_userEmail",
                schema: "BNG",
                table: "Users");
        }
    }
}

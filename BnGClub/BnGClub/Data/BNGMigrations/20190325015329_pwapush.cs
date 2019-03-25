using Microsoft.EntityFrameworkCore.Migrations;

namespace BnGClub.Data.BNGMigrations
{
    public partial class pwapush : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChildID",
                schema: "BNG",
                table: "Subscriptions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_ChildID",
                schema: "BNG",
                table: "Subscriptions",
                column: "ChildID");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Childs_ChildID",
                schema: "BNG",
                table: "Subscriptions",
                column: "ChildID",
                principalSchema: "BNG",
                principalTable: "Childs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Childs_ChildID",
                schema: "BNG",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_ChildID",
                schema: "BNG",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "ChildID",
                schema: "BNG",
                table: "Subscriptions");
        }
    }
}

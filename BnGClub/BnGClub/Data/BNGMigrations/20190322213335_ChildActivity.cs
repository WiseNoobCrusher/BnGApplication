using Microsoft.EntityFrameworkCore.Migrations;

namespace BnGClub.Data.BNGMigrations
{
    public partial class ChildActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Activities_ActivitiesID",
                schema: "BNG",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_ActivitiesID",
                schema: "BNG",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "ActivitiesID",
                schema: "BNG",
                table: "Schedules");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ActID",
                schema: "BNG",
                table: "Schedules",
                column: "ActID");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Activities_ActID",
                schema: "BNG",
                table: "Schedules",
                column: "ActID",
                principalSchema: "BNG",
                principalTable: "Activities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Activities_ActID",
                schema: "BNG",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_ActID",
                schema: "BNG",
                table: "Schedules");

            migrationBuilder.AddColumn<int>(
                name: "ActivitiesID",
                schema: "BNG",
                table: "Schedules",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ActivitiesID",
                schema: "BNG",
                table: "Schedules",
                column: "ActivitiesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Activities_ActivitiesID",
                schema: "BNG",
                table: "Schedules",
                column: "ActivitiesID",
                principalSchema: "BNG",
                principalTable: "Activities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

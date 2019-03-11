using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BnGClub.Data.BNGMigrations
{
    public partial class AddSubs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subscriptions",
                schema: "BNG",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 127, nullable: true),
                    PushEndpoint = table.Column<string>(maxLength: 512, nullable: true),
                    PushP256DH = table.Column<string>(maxLength: 512, nullable: true),
                    PushAuth = table.Column<string>(maxLength: 512, nullable: true),
                    LeaderID = table.Column<int>(nullable: true),
                    UserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Leaders_LeaderID",
                        column: x => x.LeaderID,
                        principalSchema: "BNG",
                        principalTable: "Leaders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Users_UserID",
                        column: x => x.UserID,
                        principalSchema: "BNG",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_LeaderID",
                schema: "BNG",
                table: "Subscriptions",
                column: "LeaderID");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_UserID",
                schema: "BNG",
                table: "Subscriptions",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subscriptions",
                schema: "BNG");
        }
    }
}

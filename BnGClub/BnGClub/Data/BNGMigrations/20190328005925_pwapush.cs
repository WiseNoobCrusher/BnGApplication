using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BnGClub.Data.BNGMigrations
{
    public partial class pwapush : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subs",
                schema: "MO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
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
                    table.PrimaryKey("PK_Subs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subs_Leader_LeaderID",
                        column: x => x.LeaderID,
                        principalSchema: "MO",
                        principalTable: "Leader",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);

                    table.PrimaryKey("PK_Subs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subs_User_UserID",
                        column: x => x.UserID,
                        principalSchema: "MO",
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subs_UserID",
                schema: "MO",
                table: "Subs",
                column: "UserID");




        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "Subs",
               schema: "MO");
        }
    }
}

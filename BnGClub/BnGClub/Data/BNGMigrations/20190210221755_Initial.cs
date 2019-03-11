using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BnGClub.Data.BNGMigrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BNG");

            migrationBuilder.CreateTable(
                name: "ActTypes",
                schema: "BNG",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    acttypeName = table.Column<string>(maxLength: 100, nullable: false),
                    acttypeDescription = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Leaders",
                schema: "BNG",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    leaderFName = table.Column<string>(maxLength: 50, nullable: false),
                    leaderMName = table.Column<string>(maxLength: 50, nullable: false),
                    leaderLName = table.Column<string>(maxLength: 100, nullable: false),
                    leaderEmail = table.Column<string>(maxLength: 255, nullable: false),
                    leaderPhone = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "BNG",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    userFName = table.Column<string>(maxLength: 50, nullable: false),
                    userMName = table.Column<string>(maxLength: 50, nullable: false),
                    userLName = table.Column<string>(maxLength: 100, nullable: false),
                    userEmail = table.Column<string>(maxLength: 255, nullable: false),
                    userPhone = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                schema: "BNG",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    actName = table.Column<string>(maxLength: 100, nullable: false),
                    actDescription = table.Column<string>(nullable: false),
                    actCode = table.Column<string>(maxLength: 10, nullable: false),
                    actRequirement = table.Column<string>(maxLength: 10, nullable: false),
                    actAvailablePlace = table.Column<string>(maxLength: 10, nullable: false),
                    leaderID = table.Column<int>(nullable: false),
                    acttypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.id);
                    table.ForeignKey(
                        name: "FK_Activities_ActTypes_id",
                        column: x => x.id,
                        principalSchema: "BNG",
                        principalTable: "ActTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Activities_Leaders_id",
                        column: x => x.id,
                        principalSchema: "BNG",
                        principalTable: "Leaders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeaderMessages",
                schema: "BNG",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    msgDate = table.Column<DateTime>(nullable: false),
                    msgDescription = table.Column<string>(nullable: false),
                    leaderID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaderMessages", x => x.id);
                    table.ForeignKey(
                        name: "FK_LeaderMessages_Leaders_id",
                        column: x => x.id,
                        principalSchema: "BNG",
                        principalTable: "Leaders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Childs",
                schema: "BNG",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    childFName = table.Column<string>(maxLength: 50, nullable: false),
                    childMName = table.Column<string>(maxLength: 50, nullable: false),
                    childLName = table.Column<string>(maxLength: 100, nullable: false),
                    childDOB = table.Column<DateTime>(nullable: false),
                    userID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Childs", x => x.id);
                    table.ForeignKey(
                        name: "FK_Childs_Users_id",
                        column: x => x.id,
                        principalSchema: "BNG",
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Announcements",
                schema: "BNG",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    annMessage = table.Column<string>(nullable: false),
                    annDate = table.Column<DateTime>(nullable: false),
                    leaderID = table.Column<int>(nullable: false),
                    actID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.id);
                    table.ForeignKey(
                        name: "FK_Announcements_Activities_id",
                        column: x => x.id,
                        principalSchema: "BNG",
                        principalTable: "Activities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Announcements_Leaders_id",
                        column: x => x.id,
                        principalSchema: "BNG",
                        principalTable: "Leaders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "childEnrolleds",
                schema: "BNG",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    actID = table.Column<int>(nullable: false),
                    childID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_childEnrolleds", x => new { x.actID, x.childID });
                    table.ForeignKey(
                        name: "FK_childEnrolleds_Activities_id",
                        column: x => x.id,
                        principalSchema: "BNG",
                        principalTable: "Activities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_childEnrolleds_Childs_id",
                        column: x => x.id,
                        principalSchema: "BNG",
                        principalTable: "Childs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_childEnrolleds_id",
                schema: "BNG",
                table: "childEnrolleds",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcements",
                schema: "BNG");

            migrationBuilder.DropTable(
                name: "childEnrolleds",
                schema: "BNG");

            migrationBuilder.DropTable(
                name: "LeaderMessages",
                schema: "BNG");

            migrationBuilder.DropTable(
                name: "Activities",
                schema: "BNG");

            migrationBuilder.DropTable(
                name: "Childs",
                schema: "BNG");

            migrationBuilder.DropTable(
                name: "ActTypes",
                schema: "BNG");

            migrationBuilder.DropTable(
                name: "Leaders",
                schema: "BNG");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "BNG");
        }
    }
}

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
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    acttypeName = table.Column<string>(maxLength: 100, nullable: false),
                    acttypeDescription = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Leaders",
                schema: "BNG",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    leaderFName = table.Column<string>(maxLength: 50, nullable: false),
                    leaderMName = table.Column<string>(maxLength: 50, nullable: false),
                    leaderLName = table.Column<string>(maxLength: 100, nullable: false),
                    leaderEmail = table.Column<string>(maxLength: 255, nullable: false),
                    leaderPhone = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                schema: "BNG",
                columns: table => new
                {
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    msgTo = table.Column<string>(nullable: false),
                    msgFrom = table.Column<string>(nullable: false),
                    msgBody = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "BNG",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    userFName = table.Column<string>(maxLength: 50, nullable: false),
                    userMName = table.Column<string>(maxLength: 50, nullable: false),
                    userLName = table.Column<string>(maxLength: 100, nullable: false),
                    userEmail = table.Column<string>(maxLength: 255, nullable: false),
                    userPhone = table.Column<long>(nullable: false),
                    notificationOptIn = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                schema: "BNG",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    actName = table.Column<string>(maxLength: 100, nullable: false),
                    actDescription = table.Column<string>(nullable: false),
                    actCode = table.Column<string>(maxLength: 10, nullable: false),
                    actRequirement = table.Column<string>(maxLength: 50, nullable: false),
                    actAvailablePlace = table.Column<string>(maxLength: 10, nullable: false),
                    LeaderID = table.Column<int>(nullable: false),
                    ActTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Activities_ActTypes_ActTypeID",
                        column: x => x.ActTypeID,
                        principalSchema: "BNG",
                        principalTable: "ActTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Activities_Leaders_LeaderID",
                        column: x => x.LeaderID,
                        principalSchema: "BNG",
                        principalTable: "Leaders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Childs",
                schema: "BNG",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    childFName = table.Column<string>(maxLength: 50, nullable: false),
                    childMName = table.Column<string>(maxLength: 50, nullable: false),
                    childLName = table.Column<string>(maxLength: 100, nullable: false),
                    childDOB = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Childs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Childs_Users_UserID",
                        column: x => x.UserID,
                        principalSchema: "BNG",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Announcements",
                schema: "BNG",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    annMessage = table.Column<string>(nullable: false),
                    annDate = table.Column<DateTime>(nullable: false),
                    LeaderID = table.Column<int>(nullable: false),
                    ActID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Announcements_Activities_ActID",
                        column: x => x.ActID,
                        principalSchema: "BNG",
                        principalTable: "Activities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Announcements_Leaders_LeaderID",
                        column: x => x.LeaderID,
                        principalSchema: "BNG",
                        principalTable: "Leaders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                schema: "BNG",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    startTime = table.Column<DateTime>(nullable: false),
                    endTime = table.Column<DateTime>(nullable: false),
                    dateAct = table.Column<DateTime>(nullable: false),
                    ActID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Schedules_Activities_ActID",
                        column: x => x.ActID,
                        principalSchema: "BNG",
                        principalTable: "Activities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "childEnrolleds",
                schema: "BNG",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    ActID = table.Column<int>(nullable: false),
                    ChildID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_childEnrolleds", x => new { x.ActID, x.ChildID });
                    table.ForeignKey(
                        name: "FK_childEnrolleds_Activities_ActID",
                        column: x => x.ActID,
                        principalSchema: "BNG",
                        principalTable: "Activities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_childEnrolleds_Childs_ChildID",
                        column: x => x.ChildID,
                        principalSchema: "BNG",
                        principalTable: "Childs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    UserID = table.Column<int>(nullable: false),
                    ChildID = table.Column<int>(nullable: true),
                    LeaderID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Childs_ChildID",
                        column: x => x.ChildID,
                        principalSchema: "BNG",
                        principalTable: "Childs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Leaders_LeaderID",
                        column: x => x.LeaderID,
                        principalSchema: "BNG",
                        principalTable: "Leaders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Users_UserID",
                        column: x => x.UserID,
                        principalSchema: "BNG",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ActTypeID",
                schema: "BNG",
                table: "Activities",
                column: "ActTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_LeaderID",
                schema: "BNG",
                table: "Activities",
                column: "LeaderID");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_ActID",
                schema: "BNG",
                table: "Announcements",
                column: "ActID");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_LeaderID",
                schema: "BNG",
                table: "Announcements",
                column: "LeaderID");

            migrationBuilder.CreateIndex(
                name: "IX_childEnrolleds_ChildID",
                schema: "BNG",
                table: "childEnrolleds",
                column: "ChildID");

            migrationBuilder.CreateIndex(
                name: "IX_Childs_UserID",
                schema: "BNG",
                table: "Childs",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Leaders_leaderEmail",
                schema: "BNG",
                table: "Leaders",
                column: "leaderEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ActID",
                schema: "BNG",
                table: "Schedules",
                column: "ActID");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_ChildID",
                schema: "BNG",
                table: "Subscriptions",
                column: "ChildID");

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

            migrationBuilder.CreateIndex(
                name: "IX_Users_userEmail",
                schema: "BNG",
                table: "Users",
                column: "userEmail",
                unique: true);
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
                name: "Messages",
                schema: "BNG");

            migrationBuilder.DropTable(
                name: "Schedules",
                schema: "BNG");

            migrationBuilder.DropTable(
                name: "Subscriptions",
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

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconUri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupUserPermissions",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupUserPermissions", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "GroupUserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupUserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InternalCommands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProcessedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Error = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalCommands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsEditted = table.Column<bool>(type: "bit", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OutboxMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OccuredOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Proccessed = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboxMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SessionProposals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProposingUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProposedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProposedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AcceptedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionProposals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CrossUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoughtUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WinnerUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsEnded = table.Column<bool>(type: "bit", nullable: false),
                    IsCrossTurn = table.Column<bool>(type: "bit", nullable: false),
                    LastPlacedMarkIndex = table.Column<int>(type: "int", nullable: false),
                    Marks = table.Column<string>(type: "varchar(9)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconUri = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupUsers",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JoinedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleValue = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupUsers", x => new { x.UserId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_GroupUsers_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupUserRolePermissions",
                columns: table => new
                {
                    GroupUserRoleId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupUserRolePermissions", x => new { x.Code, x.GroupUserRoleId });
                    table.ForeignKey(
                        name: "FK_GroupUserRolePermissions_GroupUserPermissions_Code",
                        column: x => x.Code,
                        principalTable: "GroupUserPermissions",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupUserRolePermissions_GroupUserRoles_GroupUserRoleId",
                        column: x => x.GroupUserRoleId,
                        principalTable: "GroupUserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "GroupUserPermissions",
                column: "Code",
                values: new object[]
                {
                    "AcceptProposal",
                    "AddUser",
                    "ChangeIconUri",
                    "ChangeName",
                    "CreateMessage",
                    "EditMessage",
                    "GetGroup",
                    "GetMessages",
                    "GetProposals",
                    "GetSession",
                    "GetUserGroups",
                    "PlaceMark",
                    "Propose",
                    "ReadMessage",
                    "RemoveUser"
                });

            migrationBuilder.InsertData(
                table: "GroupUserRoles",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Member" }
                });

            migrationBuilder.InsertData(
                table: "GroupUserRolePermissions",
                columns: new[] { "Code", "GroupUserRoleId" },
                values: new object[,]
                {
                    { "AcceptProposal", 1 },
                    { "AcceptProposal", 2 },
                    { "AddUser", 1 },
                    { "ChangeIconUri", 1 },
                    { "ChangeName", 1 },
                    { "CreateMessage", 1 },
                    { "CreateMessage", 2 },
                    { "EditMessage", 1 },
                    { "EditMessage", 2 },
                    { "GetGroup", 1 },
                    { "GetGroup", 2 },
                    { "GetMessages", 1 },
                    { "GetMessages", 2 },
                    { "GetProposals", 1 },
                    { "GetProposals", 2 },
                    { "GetSession", 1 },
                    { "GetSession", 2 },
                    { "GetUserGroups", 1 },
                    { "GetUserGroups", 2 },
                    { "PlaceMark", 1 },
                    { "PlaceMark", 2 },
                    { "Propose", 1 },
                    { "Propose", 2 },
                    { "ReadMessage", 1 },
                    { "ReadMessage", 2 },
                    { "RemoveUser", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupUserRolePermissions_GroupUserRoleId",
                table: "GroupUserRolePermissions",
                column: "GroupUserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUsers_GroupId",
                table: "GroupUsers",
                column: "GroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupUserRolePermissions");

            migrationBuilder.DropTable(
                name: "GroupUsers");

            migrationBuilder.DropTable(
                name: "InternalCommands");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "OutboxMessages");

            migrationBuilder.DropTable(
                name: "SessionProposals");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "GroupUserPermissions");

            migrationBuilder.DropTable(
                name: "GroupUserRoles");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}

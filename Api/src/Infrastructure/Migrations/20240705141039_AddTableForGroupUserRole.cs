using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTableForGroupUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupUserPermission");

            migrationBuilder.DropTable(
                name: "GroupUser");

            migrationBuilder.CreateTable(
                name: "GroupUsers",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JoinedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "GroupUserRoles",
                columns: table => new
                {
                    GroupUserUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupUserGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupUserRoles", x => new { x.GroupUserUserId, x.GroupUserGroupId });
                    table.ForeignKey(
                        name: "FK_GroupUserRoles_GroupUsers_GroupUserUserId_GroupUserGroupId",
                        columns: x => new { x.GroupUserUserId, x.GroupUserGroupId },
                        principalTable: "GroupUsers",
                        principalColumns: new[] { "UserId", "GroupId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupUserPermissions",
                columns: table => new
                {
                    GroupUserRoleGroupUserUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupUserRoleGroupUserGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupUserPermissions", x => new { x.GroupUserRoleGroupUserUserId, x.GroupUserRoleGroupUserGroupId, x.Id });
                    table.ForeignKey(
                        name: "FK_GroupUserPermissions_GroupUserRoles_GroupUserRoleGroupUserUserId_GroupUserRoleGroupUserGroupId",
                        columns: x => new { x.GroupUserRoleGroupUserUserId, x.GroupUserRoleGroupUserGroupId },
                        principalTable: "GroupUserRoles",
                        principalColumns: new[] { "GroupUserUserId", "GroupUserGroupId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupUsers_GroupId",
                table: "GroupUsers",
                column: "GroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupUserPermissions");

            migrationBuilder.DropTable(
                name: "GroupUserRoles");

            migrationBuilder.DropTable(
                name: "GroupUsers");

            migrationBuilder.CreateTable(
                name: "GroupUser",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JoinedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupUser", x => new { x.UserId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_GroupUser_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupUserPermission",
                columns: table => new
                {
                    GroupUserRoleGroupUserUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupUserRoleGroupUserGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupUserPermission", x => new { x.GroupUserRoleGroupUserUserId, x.GroupUserRoleGroupUserGroupId, x.Id });
                    table.ForeignKey(
                        name: "FK_GroupUserPermission_GroupUser_GroupUserRoleGroupUserUserId_GroupUserRoleGroupUserGroupId",
                        columns: x => new { x.GroupUserRoleGroupUserUserId, x.GroupUserRoleGroupUserGroupId },
                        principalTable: "GroupUser",
                        principalColumns: new[] { "UserId", "GroupId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupUser_GroupId",
                table: "GroupUser",
                column: "GroupId");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddKeyToGroupUserPermissionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupUserPermissions_GroupUserRoles_GroupUserRoleGroupUserUserId_GroupUserRoleGroupUserGroupId",
                table: "GroupUserPermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupUserRoles",
                table: "GroupUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupUserPermissions",
                table: "GroupUserPermissions");

            migrationBuilder.DropColumn(
                name: "GroupUserRoleGroupUserUserId",
                table: "GroupUserPermissions");

            migrationBuilder.DropColumn(
                name: "GroupUserRoleGroupUserGroupId",
                table: "GroupUserPermissions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "GroupUserPermissions");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "GroupUserRoles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "GroupUserPermissions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "GroupUserRoleValue",
                table: "GroupUserPermissions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupUserRoles",
                table: "GroupUserRoles",
                column: "Value");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupUserPermissions",
                table: "GroupUserPermissions",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUserRoles_GroupUserUserId_GroupUserGroupId",
                table: "GroupUserRoles",
                columns: new[] { "GroupUserUserId", "GroupUserGroupId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupUserPermissions_GroupUserRoleValue",
                table: "GroupUserPermissions",
                column: "GroupUserRoleValue");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupUserPermissions_GroupUserRoles_GroupUserRoleValue",
                table: "GroupUserPermissions",
                column: "GroupUserRoleValue",
                principalTable: "GroupUserRoles",
                principalColumn: "Value",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupUserPermissions_GroupUserRoles_GroupUserRoleValue",
                table: "GroupUserPermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupUserRoles",
                table: "GroupUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_GroupUserRoles_GroupUserUserId_GroupUserGroupId",
                table: "GroupUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupUserPermissions",
                table: "GroupUserPermissions");

            migrationBuilder.DropIndex(
                name: "IX_GroupUserPermissions_GroupUserRoleValue",
                table: "GroupUserPermissions");

            migrationBuilder.DropColumn(
                name: "GroupUserRoleValue",
                table: "GroupUserPermissions");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "GroupUserRoles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "GroupUserPermissions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "GroupUserRoleGroupUserUserId",
                table: "GroupUserPermissions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "GroupUserRoleGroupUserGroupId",
                table: "GroupUserPermissions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "GroupUserPermissions",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupUserRoles",
                table: "GroupUserRoles",
                columns: new[] { "GroupUserUserId", "GroupUserGroupId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupUserPermissions",
                table: "GroupUserPermissions",
                columns: new[] { "GroupUserRoleGroupUserUserId", "GroupUserRoleGroupUserGroupId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_GroupUserPermissions_GroupUserRoles_GroupUserRoleGroupUserUserId_GroupUserRoleGroupUserGroupId",
                table: "GroupUserPermissions",
                columns: new[] { "GroupUserRoleGroupUserUserId", "GroupUserRoleGroupUserGroupId" },
                principalTable: "GroupUserRoles",
                principalColumns: new[] { "GroupUserUserId", "GroupUserGroupId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}

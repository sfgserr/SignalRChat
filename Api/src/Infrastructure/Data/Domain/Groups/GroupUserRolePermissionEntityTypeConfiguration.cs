using Domain.Groups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Domain.Groups
{
    internal class GroupUserRolePermissionEntityTypeConfiguration : IEntityTypeConfiguration<GroupUserRolePermission>
    {
        public void Configure(EntityTypeBuilder<GroupUserRolePermission> builder)
        {
            builder.ToTable("GroupUserRolePermissions");

            builder.HasKey(x => new { x.Code, x.GroupUserRoleId });

            builder.HasData([
                Create(1, "AddUser"),
                Create(1, "RemoveUser"),
                Create(1, "ChangeName"),
                Create(1, "CreateMessage"),
                Create(1, "EditMessage"),
                Create(1, "ReadMessage"),
                Create(1, "GetGroup"),
                Create(1, "GetUserGroups"),
                Create(1, "ChangeIconUri"),
                Create(1, "GetMessages"),
                Create(2, "CreateMessage"),
                Create(2, "EditMessage"),
                Create(2, "ReadMessage"),
                Create(2, "GetMessages"),
                Create(2, "GetGroup"),
                Create(2, "GetUserGroups"),]);
        }

        private static GroupUserRolePermission Create(int roleId, string code) =>
            new(roleId, code);
    }
}

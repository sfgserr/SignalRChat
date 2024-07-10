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
                Create(2, "CreateMessage"),
                Create(2, "EditMessage"),
                Create(2, "ReadMessage")]);
        }

        private static GroupUserRolePermission Create(int roleId, string code) =>
            new(roleId, code);
    }
}

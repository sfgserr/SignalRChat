using Domain.Groups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Domain.Groups
{
    internal class GroupUserPermissionEntityTypeConfiguration : IEntityTypeConfiguration<GroupUserPermission>
    {
        public void Configure(EntityTypeBuilder<GroupUserPermission> builder)
        {
            builder.ToTable("GroupUserPermissions");

            builder.HasKey(p => p.Code);

            builder.HasData(SeedData.Permissions);
        }
    }
}

using Domain.Groups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Domain.Groups
{
    internal class GroupUserRoleEntityConfiguration : IEntityTypeConfiguration<GroupUserRole>
    {
        public void Configure(EntityTypeBuilder<GroupUserRole> builder)
        {
            builder.ToTable("GroupUserRoles");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Value).HasColumnName("Value");

            builder.HasMany(x => x.Permissions)
                .WithMany()
                .UsingEntity<GroupUserRolePermission>();

            builder.HasData([new { Id = 1, Value = "Admin" }, new { Id = 2, Value = "Member" }]);
        }
    }
}

using Domain.Groups;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Domain.Groups
{
    internal class GroupEntityTypeConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsMany<GroupUser>("Users", x =>
            {
                x.WithOwner().HasForeignKey("UserId");
                x.Property<UserId>("UserId");
                x.Property<GroupId>("GroupId");
                x.Property<DateTime>("JoinedDate").HasColumnName("JoinedDate");

                x.HasKey("UserId", "GroupId");

                x.OwnsOne<GroupUserRole>("Role", y =>
                {
                    y.Property<string>("Value").HasColumnName("Value");

                    y.OwnsMany<GroupUserPermission>("Permissions", z =>
                    {
                        z.Property<string>("Code").HasColumnName("Code");
                        z.WithOwner().HasForeignKey("GroupUserRoleId");
                    });
                });
            });
        }
    }
}

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
                x.ToTable("GroupUsers");

                x.WithOwner().HasForeignKey("GroupId");
                x.Property<UserId>("UserId");
                x.Property<GroupId>("GroupId");
                x.Property<DateTime>("JoinedDate").HasColumnName("JoinedDate");

                x.HasKey("UserId", "GroupId");

                x.OwnsOne<GroupUserRole>("Role", y =>
                {
                    y.ToTable("GroupUserRoles");

                    y.Property<string>("Value").HasColumnName("Value");

                    y.HasKey("Value");

                    y.OwnsMany<GroupUserPermission>("Permissions", z =>
                    {
                        z.ToTable("GroupUserPermissions");

                        z.Property<string>("Code").HasColumnName("Code");

                        z.HasKey("Code");
                    });
                });
            });
        }
    }
}

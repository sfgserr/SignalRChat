using Domain.Groups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Domain.Groups
{
    internal class GroupUserEntityTypeConfiguration : IEntityTypeConfiguration<GroupUser>
    {
        public void Configure(EntityTypeBuilder<GroupUser> builder)
        {
            builder.HasKey(g => new { g.UserId, g.GroupId });

            builder.Property(g => g.JoinedDate).HasColumnName("JoinedDate");

            builder.HasOne(g => g.Role)
                .WithMany(r => r.Users);
        }
    }
}

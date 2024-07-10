using Domain.Groups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Domain.Groups
{
    internal class GroupEntityTypeConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Groups");

            builder.HasKey(x => x.Id);

            builder.Property<DateTime>("CreationDate").HasColumnName("CreationDate");

            builder.HasMany(x => x.Users)
                .WithOne()
                .HasForeignKey(x => x.GroupId);
        }
    }
}

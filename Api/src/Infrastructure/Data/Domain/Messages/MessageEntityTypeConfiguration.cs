using Domain.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Domain.Messages
{
    internal class MessageEntityTypeConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.SenderId).HasColumnName("SenderId");
            builder.Property(m => m.ToGroupId).HasColumnName("ToGroupId");
            builder.Property(m => m.Type).HasColumnName("Type");
            builder.Property(m => m.CreationTime).HasColumnName("CreationTime");
        }
    }
}

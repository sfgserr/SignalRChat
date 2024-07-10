using Infrastructure.Outbox;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Domain.Outbox
{
    internal class OutboxEntityTypeConfiguration : IEntityTypeConfiguration<OutboxMessage>
    {
        public void Configure(EntityTypeBuilder<OutboxMessage> builder)
        {
            builder.ToTable("OutboxMessages");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Message).HasColumnName("Message");
            builder.Property(o => o.Type).HasColumnName("Type");
            builder.Property(o => o.OccuredOn).HasColumnName("OccuredOn");
        }
    }
}

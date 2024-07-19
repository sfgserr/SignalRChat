using Domain.Sessions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Domain.Sessions
{
    internal class SessionEntityTypeConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.ToTable("Sessions");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.CrossUserId).HasColumnName("CrossUserId");
            builder.Property(s => s.NoughtUserId).HasColumnName("NoughtUserId");
            builder.Property(s => s.Marks)
                .HasConversion(m => m.Select(m => m.Value), m => m.Select(c => Mark.Parse(c)).ToList().AsReadOnly()!)
                .HasColumnName("Marks");
        }
    }
}

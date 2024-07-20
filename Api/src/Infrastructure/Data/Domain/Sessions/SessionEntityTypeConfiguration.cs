using Domain.Sessions;
using Infrastructure.Data.ValueConversion;
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
            builder.Property<Mark?[]>("_marks")
                .HasConversion(new MarkToStringValueConverter())
                .HasColumnType("varchar(9)")
                .HasColumnName("Marks");
        }
    }
}

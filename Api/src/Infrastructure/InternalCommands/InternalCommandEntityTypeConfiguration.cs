﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.InternalCommands
{
    internal class InternalCommandEntityTypeConfiguration : IEntityTypeConfiguration<InternalCommand>
    {
        public void Configure(EntityTypeBuilder<InternalCommand> builder)
        {
            builder.ToTable("InternalCommands");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Type).HasColumnName("Type");
            builder.Property(x => x.Data).HasColumnName("Data");
        }
    }
}

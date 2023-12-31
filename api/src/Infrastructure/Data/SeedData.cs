﻿using Domain;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public static class SeedData
    {
        public static readonly string DefaultUserSenderId = "197d0438-e04b-453d-b5de-eca05960c6ae";

        public static readonly string DefaultUserReceiverId = "234d0438-e04b-453e-b8dc-dcba15070c6ae";

        public static readonly MessageId DefaultMessageId =
            new MessageId(new Guid("4c510cfe-5d61-4a46-a3d9-c4313426655f"));

        public static void Seed(ModelBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Entity<Message>()
                   .HasData(new Message(DefaultMessageId, DefaultUserSenderId, DefaultUserReceiverId, "Hello", DateTime.Now));

            builder.Entity<Message>()
                   .HasKey(m => m.Id);

            builder.Entity<Message>()
                   .Property(m => m.Id)
                   .HasConversion(id => id.Id,
                                  id => new MessageId(id));
        }
    }
}

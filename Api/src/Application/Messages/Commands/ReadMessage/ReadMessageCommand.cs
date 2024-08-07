﻿using Application.Cqrs.Commands;

namespace Application.Messages.Commands.ReadMessage
{
    public class ReadMessageCommand(Guid messageId) : ICommand
    {
        public Guid MessageId { get; } = messageId;
    }
}

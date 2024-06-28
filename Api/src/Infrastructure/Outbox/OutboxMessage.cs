﻿
namespace Infrastructure.Outbox
{
    public class OutboxMessage
    {
        public OutboxMessage(Guid id, string type, string message, DateTime occuredOn)
        {
            Id = id;
            Type = type;
            Message = message;
            OccuredOn = occuredOn;
        }

        private OutboxMessage()
        {

        }

        public Guid Id { get; }

        public string Type { get; }

        public string Message { get; }

        public DateTime OccuredOn { get; }

        public DateTime? Proccessed { get; set; }
    }
}

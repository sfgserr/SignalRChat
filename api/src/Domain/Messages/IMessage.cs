using Domain.ValueObjects;

namespace Domain.Messages
{
    interface IMessage
    {
        MessageId Id { get; }
    }
}

using Domain.ValueObjects;

namespace Domain
{
    interface IMessage
    {
        MessageId Id { get; }
    }
}

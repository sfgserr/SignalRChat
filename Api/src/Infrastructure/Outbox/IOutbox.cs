
namespace Infrastructure.Outbox
{
    internal interface IOutbox
    {
        void Add(OutboxMessage message);
    }
}

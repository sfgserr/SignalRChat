using Domain.SeedWork;

namespace Domain.Messages
{
    public class MessageId(Guid id) : ValueObject
    {
        public Guid Id { get; } = id;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}

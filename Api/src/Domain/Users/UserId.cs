using Domain.SeedWork;

namespace Domain.Users
{
    public class UserId(Guid id) : ValueObject
    {
        public Guid Id { get; } = id;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}

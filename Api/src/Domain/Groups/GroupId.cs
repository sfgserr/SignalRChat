
using Domain.SeedWork;

namespace Domain.Groups
{
    public class GroupId(Guid id) : ValueObject
    {
        public Guid Id { get; } = id;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}

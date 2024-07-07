
namespace Domain.SeedWork
{
    public abstract class TypedIdValueBase(Guid id) : ValueObject
    {
        public Guid Value { get; } = id;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

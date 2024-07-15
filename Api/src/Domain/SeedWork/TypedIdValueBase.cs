
namespace Domain.SeedWork
{
    public abstract class TypedIdValueBase(Guid value) : ValueObject
    {
        public Guid Value { get; } = value;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

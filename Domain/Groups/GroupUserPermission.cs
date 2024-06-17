using Domain.SeedWork;

namespace Domain.Groups
{
    public class GroupUserPermission(string code) : ValueObject
    {
        public string Code { get; } = code;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Code;
        }
    }
}

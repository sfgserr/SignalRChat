using Domain.SeedWork;

namespace Domain.Groups
{
    public class GroupUserPermission : ValueObject
    {
        public GroupUserPermission(string code)
        {
            Code = code;
        }

        public string Code { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Code;
        }
    }
}

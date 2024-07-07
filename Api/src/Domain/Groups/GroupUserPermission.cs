using Domain.SeedWork;

namespace Domain.Groups
{
    public class GroupUserPermission : ValueObject
    {
        public GroupUserPermission(string code)
        {
            Code = code;
        }

        private GroupUserPermission()
        {

        }

        public string Code { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Code;
        }
    }
}

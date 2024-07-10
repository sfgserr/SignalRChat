using Domain.SeedWork;

namespace Domain.Groups
{
    public class GroupUserPermission : Entity
    {
        public GroupUserPermission(string code)
        {
            Code = code;
        }

        private GroupUserPermission()
        {

        }

        public string Code { get; }
    }
}

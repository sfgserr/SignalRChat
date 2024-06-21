using Domain.Groups;

namespace Application.Groups.Queries.GetUserGroups
{
    public class GroupDto(Group group)
    {
        public Guid Id { get; } = group.Id.Id;

        public string Name { get; } = group.Name;

        public string IconUri { get; } = group.IconUri;
    }
}

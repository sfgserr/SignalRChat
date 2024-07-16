using Application.Cqrs.Queries;

namespace Application.Groups.Queries.GetGroup
{
    public class GetGroupQuery(Guid groupId) : IQuery<GroupDto>
    {
        public Guid GroupId { get; } = groupId;
    }
}

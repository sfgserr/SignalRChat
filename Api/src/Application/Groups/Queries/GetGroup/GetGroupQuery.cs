using Application.Cqrs.Queries;

namespace Application.Groups.Queries.GetGroup
{
    public sealed class GetGroupQuery(Guid groupId) : IQuery<GroupDto>
    {
        public Guid GroupId { get; } = groupId;
    }
}

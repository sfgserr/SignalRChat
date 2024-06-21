using Application.Cqrs.Queries;

namespace Application.Groups.Queries.GetGroup
{
    public interface IGetGroupQueryHandler : IQueryHandler<GetGroupQuery, GroupDto>
    {
    }
}

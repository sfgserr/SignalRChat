using Application.Cqrs.Queries;

namespace Application.Messages.Queries.GetMessages
{
    public class GetMessagesQuery(Guid groupId) : IQuery<IList<GetMessageDto>>
    {
        public Guid GroupId { get; } = groupId;
    }
}

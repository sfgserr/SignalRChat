using Application.Cqrs.Queries;

namespace Application.Messages.Queries.GetMessages
{
    public interface IGetMessagesQueryHandler : IQueryHandler<GetMessagesQuery, IList<MessageDto>>
    {
    }
}

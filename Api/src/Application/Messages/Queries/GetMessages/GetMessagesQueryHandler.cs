using Application.Cqrs.Queries;
using Domain.Groups;
using Domain.Messages;

namespace Application.Messages.Queries.GetMessages
{
    public sealed class GetMessagesQueryHandler(IMessageRepository messageRepository) : 
        IQueryHandler<GetMessagesQuery, IList<MessageDto>>
    {
        private readonly IMessageRepository _messageRepository = messageRepository;

        public async Task<IList<MessageDto>> Handle(GetMessagesQuery query)
        {
            IList<Message> messages = await _messageRepository.Get(new GroupId(query.GroupId));

            return messages.Select(m => new MessageDto(m)).ToList();
        }
    }
}

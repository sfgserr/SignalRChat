using Application.Cqrs.Queries;
using Domain.Groups;
using Domain.Messages;

namespace Application.Messages.Queries.GetMessages
{
    internal class GetMessagesQueryHandler : IQueryHandler<GetMessagesQuery, IList<GetMessageDto>>
    {
        private readonly IMessageRepository _messageRepository;

        internal GetMessagesQueryHandler(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<IList<GetMessageDto>> Handle(GetMessagesQuery query)
        {
            IList<Message> messages = await _messageRepository.Get(new GroupId(query.GroupId));

            return messages.Select(m => new GetMessageDto(m)).ToList();
        }
    }
}

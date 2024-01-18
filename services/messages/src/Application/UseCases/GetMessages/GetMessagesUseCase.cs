using Application.Services;
using Domain;

namespace Application.UseCases.GetMessages
{
    public class GetMessagesUseCase : IGetMessagesUseCase
    {
        private readonly IUserService _userService;
        private readonly IMessageRepository _repository;

        private IOutputPort _outputPort;

        public GetMessagesUseCase(IUserService userService, IMessageRepository repository)
        {
            _userService = userService;
            _repository = repository;

            _outputPort = new GetMessagesPresenter();
        }

        public async Task Execute()
        {
            string userId = _userService.GetCurrentUserId();

            IList<Message> messages = await GetMessages(userId);

            _outputPort.Ok(messages);
        }

        private async Task<IList<Message>> GetMessages(string userId)
        {
            IList<Message> messages = await _repository.GetMessages();

            return messages.Where(m => m.ExternalUserSenderId == userId || m.ExternalUserReceiverId == userId)
                           .ToList();
        }

        public void SetOutputPort(IOutputPort outputPort)
        {
            _outputPort = outputPort;
        }
    }
}

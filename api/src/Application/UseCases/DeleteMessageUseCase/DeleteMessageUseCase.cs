
using Application.Services;
using Domain;
using Domain.ValueObjects;

namespace Application.UseCases.DeleteMessageUseCase
{
    public class DeleteMessageUseCase : IDeleteMessageUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMessageRepository _messageRepository;

        private IOutputPort _outputPort;

        public DeleteMessageUseCase(IUnitOfWork unitOfWork, IMessageRepository messageRepository)
        {
            _unitOfWork = unitOfWork;
            _messageRepository = messageRepository;

            _outputPort = new DeleteMessagePresenter();
        }

        public async Task Execute(Guid messageId) =>
            await DeleteMessage(new MessageId(messageId));

        private async Task DeleteMessage(MessageId messageId)
        {
            Message message = await _messageRepository.GetMessage(messageId);

            if (message == null)
            {
                _outputPort.NotFound();
                return;
            }

            await _messageRepository.Delete(messageId);

            await _unitOfWork.Save();
        }

        public void SetOutputPort(IOutputPort outputPort)
        {
            _outputPort = outputPort;
        }
    }
}

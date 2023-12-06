using Application.Services;
using Domain;
using Domain.ValueObjects;

namespace Application.UseCases.EditMessage
{
    public class EditMessageUseCase : IEditMessageUseCase
    {
        private readonly IMessageRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        private IOutputPort _outputPort;

        public EditMessageUseCase(IMessageRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;

            _outputPort = new EditMessagePresenter();
        }

        public async Task Execute(Guid messageId, string text) =>
            await EditMessage(new MessageId(messageId), text);

        private async Task EditMessage(MessageId messageId, string text)
        {
            Message message = await _repository.GetMessage(messageId);

            if (message != null)
            {
                message.Text = text;

                _repository.Update(message);

                _outputPort.Ok(message);

                await _unitOfWork.Save();

                return;
            }

            _outputPort.NotFound();
        }

        public void SetOutputPort(IOutputPort outputPort)
        {
            _outputPort = outputPort;
        }
    }
}

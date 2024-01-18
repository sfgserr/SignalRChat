
namespace Application.UseCases.EditMessage
{
    public class EditMessageValidationUseCase : IEditMessageUseCase
    {
        private readonly IEditMessageUseCase _editMessageUseCase;

        private IOutputPort _outputPort;

        public EditMessageValidationUseCase(IEditMessageUseCase editMessageUseCase)
        {
            _editMessageUseCase = editMessageUseCase;

            _outputPort = new EditMessagePresenter();
        }

        public async Task Execute(Guid messageId, string text)
        {
            if (messageId == Guid.Empty || text == string.Empty) 
            {
                _outputPort.Invalid();
                return;
            }

            await _editMessageUseCase.Execute(messageId, text);
        }

        public void SetOutputPort(IOutputPort outputPort)
        {
            _outputPort = outputPort;
            _editMessageUseCase.SetOutputPort(outputPort);
        }
    }
}

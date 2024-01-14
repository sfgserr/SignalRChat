
namespace Application.UseCases.SendMessage
{
    public class SendMessageValidationUseCase : ISendMessageUseCase
    {
        private IOutputPort _outputPort;

        private readonly ISendMessageUseCase _useCase;

        public SendMessageValidationUseCase(ISendMessageUseCase useCase)
        {
            _useCase = useCase;

            _outputPort = new SendMessagePresenter();
        }

        public async Task Execute(string userReceiverId, string text)
        {
            if (string.IsNullOrWhiteSpace(userReceiverId) || string.IsNullOrWhiteSpace(text))
            {
                _outputPort.Invalid();
                return;
            }

            await _useCase.Execute(userReceiverId, text);
        }

        public void SetOutputPort(IOutputPort outputPort)
        {
            _outputPort = outputPort;
            _useCase.SetOutputPort(_outputPort);
        }
    }
}

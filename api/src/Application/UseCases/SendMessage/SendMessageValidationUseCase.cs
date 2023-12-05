
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

        public async Task Execute(string userSenderId, string userReceiverId, string text)
        {
            if (string.IsNullOrWhiteSpace(userSenderId) || string.IsNullOrWhiteSpace(userReceiverId) || string.IsNullOrWhiteSpace(text))
            {
                _outputPort.Invalid();
                return;
            }

            await _useCase.Execute(userSenderId, userReceiverId, text);
        }

        public void SetOutputPort(IOutputPort outputPort)
        {
            _outputPort = outputPort;
            _useCase.SetOutputPort(_outputPort);
        }
    }
}

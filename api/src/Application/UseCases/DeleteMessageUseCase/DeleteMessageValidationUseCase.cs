
namespace Application.UseCases.DeleteMessageUseCase
{
    public class DeleteMessageValidationUseCase : IDeleteMessageUseCase
    {
        private readonly IDeleteMessageUseCase _deletMessageUseCase;

        private IOutputPort _outputPort;

        public DeleteMessageValidationUseCase(IDeleteMessageUseCase deletMessageUseCase)
        {
            _deletMessageUseCase = deletMessageUseCase;

            _outputPort = new DeleteMessagePresenter();
        }

        public async Task Execute(Guid messageId)
        {
            if (messageId == Guid.Empty)
            {
                _outputPort.Invalid();
                return;
            }

            await _deletMessageUseCase.Execute(messageId);
        }

        public void SetOutputPort(IOutputPort outputPort)
        {
            _outputPort = outputPort;
            _deletMessageUseCase.SetOutputPort(outputPort);
        }
    }
}

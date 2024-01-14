
namespace Application.UseCases.SendMessage
{
    public interface ISendMessageUseCase
    {
        Task Execute(string userReceiverId, string text);

        void SetOutputPort(IOutputPort outputPort);
    }
}

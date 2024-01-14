
namespace Application.UseCases.GetMessages
{
    public interface IGetMessagesUseCase
    {
        Task Execute();

        void SetOutputPort(IOutputPort outputPort);
    }
}


namespace Application.UseCases.DeleteMessageUseCase
{
    public interface IDeleteMessageUseCase
    {
        Task Execute(Guid messageId);

        void SetOutputPort(IOutputPort outputPort);
    }
}

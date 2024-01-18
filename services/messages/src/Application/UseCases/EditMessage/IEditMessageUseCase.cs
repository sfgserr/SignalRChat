
namespace Application.UseCases.EditMessage
{
    public interface IEditMessageUseCase
    {
        Task Execute(Guid messageId, string text);

        void SetOutputPort(IOutputPort outputPort);
    }
}

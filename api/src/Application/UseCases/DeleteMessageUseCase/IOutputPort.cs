using Domain;

namespace Application.UseCases.DeleteMessageUseCase
{
    public interface IOutputPort
    {
        void Ok(Message message);

        void NotFound();

        void Invalid();
    }
}

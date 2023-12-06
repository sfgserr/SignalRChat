using Domain;

namespace Application.UseCases.EditMessage
{
    public interface IOutputPort
    {
        void Ok(Message message);

        void Invalid();

        void NotFound();
    }
}

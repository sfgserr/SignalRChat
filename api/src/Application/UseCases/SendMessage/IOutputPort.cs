using Domain;

namespace Application.UseCases.SendMessage
{
    public interface IOutputPort
    {
        void Ok(Message message);

        void Invalid();
    }
}

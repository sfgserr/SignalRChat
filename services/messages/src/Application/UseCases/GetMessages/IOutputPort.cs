using Domain;

namespace Application.UseCases.GetMessages
{
    public interface IOutputPort
    {
        void Ok(IList<Message> messages);
    }
}

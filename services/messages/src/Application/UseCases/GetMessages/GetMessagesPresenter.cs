using Domain;

namespace Application.UseCases.GetMessages
{
    public class GetMessagesPresenter : IOutputPort
    {
        public IList<Message> Messages { get; set; }

        public void Ok(IList<Message> messages)
        {
            Messages = messages;
        }
    }
}

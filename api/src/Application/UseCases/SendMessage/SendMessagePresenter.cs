using Domain;

namespace Application.UseCases.SendMessage
{
    internal class SendMessagePresenter : IOutputPort
    {
        public Message? Message { get; set; }
        public bool IsTextEmpty { get; set; }

        public void Ok(Message message)
        {
            Message = message;
        }

        public void Invalid()
        {
            IsTextEmpty = true;
        }
    }
}

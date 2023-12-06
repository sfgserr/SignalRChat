using Domain;

namespace Application.UseCases.EditMessage
{
    public class EditMessagePresenter : IOutputPort
    {
        public bool IsInvalid { get; set; }
        public bool IsNotFound { get; set; }
        public Message? Message { get; set; }

        public void Invalid()
        {
            IsInvalid = true;
        }

        public void NotFound()
        {
            IsNotFound = true;
        }

        public void Ok(Message message)
        {
            Message = message;
        }
    }
}

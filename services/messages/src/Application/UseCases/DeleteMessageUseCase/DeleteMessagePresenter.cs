using Domain;

namespace Application.UseCases.DeleteMessageUseCase
{
    public class DeleteMessagePresenter : IOutputPort
    {
        public Message? Message { get; set; }
        public bool IsInvalid { get; set; }
        public bool IsNotFound { get; set; }

        public void Ok(Message message)
        {
            Message = message;
        }

        public void Invalid()
        {
            IsInvalid = true;
        }

        public void NotFound()
        {
            IsNotFound = true;
        }
    }
}

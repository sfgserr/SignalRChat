using Application.Messages.Commands.SendMessage;

namespace Application.Contracts
{
    public interface ISender
    {
        Task Send(MessageDto message);
    }
}

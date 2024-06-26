
namespace Application.Contracts
{
    public interface IEmailService
    {
        Task Send(string email, string message);
    }
}

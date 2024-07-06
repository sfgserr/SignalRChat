using Application.Contracts;

namespace Infrastructure.Email
{
    internal class EmailService : IEmailService
    {
        public async Task Send(string email, string message)
        {
            await Task.CompletedTask;
        }
    }
}

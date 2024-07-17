using Application.Contracts;

namespace IntegrationTests.SeedWork
{
    internal class SenderMock : ISender
    {
        public Task Send(SendMessageDto message) =>
            Task.CompletedTask;
    }
}

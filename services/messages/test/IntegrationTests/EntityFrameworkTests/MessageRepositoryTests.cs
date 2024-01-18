using Domain;
using Domain.ValueObjects;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;

namespace IntegrationTests.EntityFrameworkTests
{
    public class MessageRepositoryTests : IClassFixture<StandardFixture>
    {
        private readonly StandardFixture _fixture;

        public MessageRepositoryTests(StandardFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Add()
        {
            Message message = new Message(new MessageId(Guid.NewGuid()), SeedData.DefaultUserSenderId,
                                          SeedData.DefaultUserReceiverId, "Hello", DateTime.Now);

            MessageRepository repository = new MessageRepository(_fixture.Context);

            await repository.Add(message);

            await _fixture.Context.SaveChangesAsync();

            bool isAnyMessage = _fixture.Context.Messages.Any(m => m.Id == message.Id);

            Assert.True(isAnyMessage);
        }
    }
}

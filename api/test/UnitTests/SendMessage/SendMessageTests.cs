using Application.UseCases.SendMessage;

namespace UnitTests.SendMessage
{
    public sealed class SendMessageTests : IClassFixture<StandardFixture>
    {
        private readonly StandardFixture _fixture;

        public SendMessageTests(StandardFixture fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [ClassData(typeof(ValidDataSetup))]
        public async Task SendMessage_Returns_Ok(string userSenderId, string userReceiverId, string text)
        {
            SendMessagePresenter presenter = new SendMessagePresenter();

            SendMessageUseCase sut = new SendMessageUseCase(_fixture.UnitOfWorkFake, _fixture.MessageRepositoryFake);

            sut.SetOutputPort(presenter);

            await sut.Execute(userSenderId, userReceiverId, text);

            Assert.NotNull(presenter.Message);
        }

        [Theory]
        [ClassData(typeof(InvalidDataSetup))]
        public async Task SendMessage_Returns_Invalid(string userSenderId, string userReceiverId, string text)
        {
            SendMessagePresenter presenter = new SendMessagePresenter();

            SendMessageUseCase sendMessageUseCase = new SendMessageUseCase(_fixture.UnitOfWorkFake, _fixture.MessageRepositoryFake);

            SendMessageValidationUseCase sut = new SendMessageValidationUseCase(sendMessageUseCase);

            sut.SetOutputPort(presenter);

            await sut.Execute(userSenderId, userReceiverId, text);

            Assert.Null(presenter.Message);
        }
    }
}

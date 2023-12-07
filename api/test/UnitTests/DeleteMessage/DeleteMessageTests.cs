using Application.UseCases.DeleteMessageUseCase;

namespace UnitTests.DeleteMessage
{
    public class DeleteMessageTests : IClassFixture<StandardFixture>
    {
        private readonly StandardFixture _fixture;

        public DeleteMessageTests(StandardFixture fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [ClassData(typeof(ValidDataSetup))]
        public async Task DeleteMessage_Returns_Ok(Guid id)
        {
            DeleteMessagePresenter presenter = new DeleteMessagePresenter();

            DeleteMessageUseCase sut = new DeleteMessageUseCase(_fixture.UnitOfWorkFake, _fixture.MessageRepositoryFake);

            sut.SetOutputPort(presenter);

            await sut.Execute(id);

            Assert.NotNull(presenter.Message);
        }

        [Theory]
        [ClassData(typeof(InvalidDataSetup))]
        public async Task DeleteMessage_Returns_Invalid(Guid id)
        {
            DeleteMessagePresenter presenter = new DeleteMessagePresenter();

            DeleteMessageUseCase deleteMessageUseCase = new DeleteMessageUseCase(_fixture.UnitOfWorkFake, _fixture.MessageRepositoryFake);

            DeleteMessageValidationUseCase sut = new DeleteMessageValidationUseCase(deleteMessageUseCase);

            sut.SetOutputPort(presenter);

            await sut.Execute(id);

            Assert.Null(presenter.Message);
        }
    }
}

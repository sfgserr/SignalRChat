using Application.UseCases.EditMessage;

namespace UnitTests.EditMessage
{
    public class EditMessageTests : IClassFixture<StandardFixture>
    {
        private readonly StandardFixture _fixture;

        public EditMessageTests(StandardFixture fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [ClassData(typeof(ValidDataSetup))]
        public async Task EditMessage_Returns_Ok(Guid id, string text)
        {
            EditMessagePresenter presenter = new EditMessagePresenter();

            EditMessageUseCase sut = new EditMessageUseCase(_fixture.MessageRepositoryFake, _fixture.UnitOfWorkFake);

            sut.SetOutputPort(presenter);

            await sut.Execute(id, text);

            Assert.NotNull(presenter.Message);
        }

        [Theory]
        [ClassData(typeof(InvalidDataSetup))]
        public async Task EditMessage_Returns_Invalid(Guid id, string text)
        {
            EditMessagePresenter presenter = new EditMessagePresenter();

            EditMessageUseCase editMessageUseCase = new EditMessageUseCase(_fixture.MessageRepositoryFake, _fixture.UnitOfWorkFake);

            EditMessageValidationUseCase sut = new EditMessageValidationUseCase(editMessageUseCase);

            sut.SetOutputPort(presenter);

            await sut.Execute(id, text);

            Assert.Null(presenter.Message);
        }
    }
}

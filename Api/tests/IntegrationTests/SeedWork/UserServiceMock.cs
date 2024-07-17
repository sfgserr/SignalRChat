using Application.Contracts;

namespace IntegrationTests.SeedWork
{
    internal class UserServiceMock : IUserService
    {
        private readonly Guid Guid = Guid.Parse("5325c3a9-5173-45d3-b805-b6f225be612d");

        public Guid GetUserId() => Guid;
    }
}

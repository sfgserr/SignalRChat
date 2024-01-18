using Infrastructure.Data;
using Infrastructure.Data.Repositories;

namespace UnitTests
{
    public sealed class StandardFixture
    {
        public StandardFixture()
        {
            UnitOfWorkFake = new UnitOfWorkFake();
            ContextFake = new ChatContextFake();
            MessageRepositoryFake = new MessageRepositoryFake(ContextFake);
        }

        public UnitOfWorkFake UnitOfWorkFake { get; }
        public ChatContextFake ContextFake { get; }
        public MessageRepositoryFake MessageRepositoryFake { get; }
    }
}

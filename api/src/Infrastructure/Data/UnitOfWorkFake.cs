using Application.Services;

namespace Infrastructure.Data
{
    public class UnitOfWorkFake : IUnitOfWork
    {
        public async Task Save() => await Task.FromResult(0);
    }
}

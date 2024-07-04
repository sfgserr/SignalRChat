using Application.Cqrs.Commands;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Processing
{
    internal class UnitOfWorkCommandHandlerDecorator<T> : ICommandHandler<T> where T : ICommand
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommandHandler<T> _decorated;

        public UnitOfWorkCommandHandlerDecorator(IUnitOfWork unitOfWork, ICommandHandler<T> decorated)
        {
            _unitOfWork = unitOfWork;
            _decorated = decorated;
        }

        public async Task Handle(T command)
        {
            IDbContextTransaction transaction = await _unitOfWork.BeginTransactionAsync();

            await _decorated.Handle(command);

            await _unitOfWork.SaveChangesAsync(transaction);
        }
    }
}

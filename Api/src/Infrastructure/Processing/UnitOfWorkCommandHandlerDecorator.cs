using Application.Cqrs.Commands;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Processing
{
    internal class UnitOfWorkCommandHandlerDecorator<T>(IUnitOfWork unitOfWork, ICommandHandler<T> decorated) : 
        ICommandHandler<T> where T : ICommand
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ICommandHandler<T> _decorated = decorated;

        public async Task Handle(T command)
        {
            IDbContextTransaction transaction = await _unitOfWork.BeginTransactionAsync();

            await _decorated.Handle(command);

            await _unitOfWork.SaveChangesAsync(transaction);
        }
    }
}

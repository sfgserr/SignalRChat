using Application.Cqrs.Commands;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Processing
{
    internal class UnitOfWorkCommandHandlerWithResultDecorator<T, TResult> : 
        ICommandHandlerWithResult<T, TResult> where T : ICommandWithResult<TResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommandHandlerWithResult<T, TResult> _decorated;

        public UnitOfWorkCommandHandlerWithResultDecorator(IUnitOfWork unitOfWork, 
            ICommandHandlerWithResult<T, TResult> decorated)
        {
            _unitOfWork = unitOfWork;
            _decorated = decorated;
        }

        public async Task<TResult> Handle(T command)
        {
            if (_unitOfWork.HasActiveTransaction)
                return await _decorated.Handle(command);

            IDbContextTransaction transaction = await _unitOfWork.BeginTransactionAsync();

            TResult result = await _decorated.Handle(command);

            await _unitOfWork.SaveChangesAsync(transaction);

            return result;
        }
    }
}

using Application.Cqrs.Commands;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Processing
{
    internal class UnitOfWorkCommandHandlerDecorator<T> : ICommandHandler<T> where T : ICommand
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommandHandler<T> _decorated;
        private readonly ApplicationContext _applicationContext;

        public UnitOfWorkCommandHandlerDecorator(
            IUnitOfWork unitOfWork, 
            ICommandHandler<T> decorated, 
            ApplicationContext applicationContext)
        {
            _unitOfWork = unitOfWork;
            _decorated = decorated;
            _applicationContext = applicationContext;
        }

        public async Task Handle(T command)
        {
            if (_unitOfWork.HasActiveTransaction)
            {
                await _decorated.Handle(command);
                await ProcessInternalCommand(command);

                return;
            }

            IDbContextTransaction transaction = await _unitOfWork.BeginTransactionAsync();

            await _decorated.Handle(command);

            await ProcessInternalCommand(command);

            await _unitOfWork.SaveChangesAsync(transaction);
        }

        private async Task ProcessInternalCommand(T command)
        {
            if (command is InternalCommandBase internalCommandBase)
            {
                var internalCommand = await _applicationContext.InternalCommands
                    .FirstOrDefaultAsync(i => i.Id == internalCommandBase.Id);

                if (internalCommand != null)
                    internalCommand.ProcessedDate = DateTime.Now;
            }
        }
    }
}

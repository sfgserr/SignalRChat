using Application.UseCases.DeleteMessageUseCase;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebApi.Hubs;
using WebApi.ViewModels;

namespace WebApi.UseCases.DeleteMessage
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MessageController : Controller, IOutputPort
    {
        private readonly IDeleteMessageUseCase _useCase;
        private readonly IHubContext<ChatHub> _hubContext;

        private IActionResult _viewModel;

        public MessageController(IDeleteMessageUseCase useCase, IHubContext<ChatHub> hubContext)
        {
            _useCase = useCase;
            _hubContext = hubContext;
        }

        async void IOutputPort.Ok(Message message)
        {
            _viewModel = Ok(new MessageModel(message));
            await _hubContext.Clients.User(message.ExternalUserReceiverId).SendAsync("OnDelete", message.Id);
        }

        void IOutputPort.Invalid()
        {
            _viewModel = BadRequest();
        }

        void IOutputPort.NotFound()
        {
            _viewModel = NotFound();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteMessage(Guid id)
        {
            _useCase.SetOutputPort(this);

            await _useCase.Execute(id);

            return _viewModel;
        }
    }
}

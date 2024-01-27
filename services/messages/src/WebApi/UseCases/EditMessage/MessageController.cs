using Application.UseCases.EditMessage;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebApi.Hubs;
using WebApi.ViewModels;

namespace WebApi.UseCases.EditMessage
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MessageController : Controller, IOutputPort
    {
        private readonly IEditMessageUseCase _useCase;
        private readonly IHubContext<ChatHub> _hubContext;

        private IActionResult _viewModel;

        public MessageController(IEditMessageUseCase useCase, IHubContext<ChatHub> hubContext)
        {
            _useCase = useCase;
            _hubContext = hubContext;
        }

        async void IOutputPort.Ok(Message message)
        {
            _viewModel = Ok(new MessageModel(message));
            await _hubContext.Clients.User(message.ExternalUserReceiverId).SendAsync("Edit", message.Text, message.Id.Id);
        }

        void IOutputPort.Invalid()
        {
            _viewModel = BadRequest();
        }

        void IOutputPort.NotFound()
        {
            _viewModel = NotFound();
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> EditMessage(Guid id, string text)
        {
            _useCase.SetOutputPort(this);

            await _useCase.Execute(id, text);

            return _viewModel;
        } 
    }
}

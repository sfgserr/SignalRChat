using Application.UseCases.SendMessage;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebApi.Hubs;
using WebApi.ViewModels;

namespace WebApi.UseCases.SendMessage
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MessageController : Controller, IOutputPort
    {
        private readonly ISendMessageUseCase _useCase;
        private readonly IHubContext<ChatHub> _hubContext;

        private IActionResult _viewModel;

        public MessageController(ISendMessageUseCase useCase, IHubContext<ChatHub> hubContext)
        {
            _useCase = useCase;
            _hubContext = hubContext;
        }

        async void IOutputPort.Ok(Message message)
        {
            _viewModel = Ok(new MessageModel(message));
            await _hubContext.Clients.User(message.ExternalUserReceiverId).SendAsync("Receive", message.Text, message.ExternalUserSenderId);
        }

        void IOutputPort.Invalid()
        {
            _viewModel = BadRequest();
        }

        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendMessage(string receiverId, string text)
        {
            _useCase.SetOutputPort(this);

            await _useCase.Execute(receiverId, text);

            return _viewModel;
        }
    }
}

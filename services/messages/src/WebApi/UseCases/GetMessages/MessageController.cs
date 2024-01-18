using Application.UseCases.GetMessages;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels;

namespace WebApi.UseCases.GetMessages
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MessageController : Controller, IOutputPort
    {
        private readonly IGetMessagesUseCase _useCase;

        private IActionResult _viewModel;

        public MessageController(IGetMessagesUseCase useCase)
        {
            _useCase = useCase;
        }

        void IOutputPort.Ok(IList<Message> messages)
        {
            _viewModel = Ok(messages.Select(m => new MessageModel(m)));
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetMessages()
        {
            _useCase.SetOutputPort(this);

            await _useCase.Execute();

            return _viewModel;
        }
    }
}

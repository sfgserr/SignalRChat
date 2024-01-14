using Application.UseCases.EditMessage;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels;

namespace WebApi.UseCases.EditMessage
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MessageController : Controller, IOutputPort
    {
        private readonly IEditMessageUseCase _useCase;

        private IActionResult _viewModel;

        public MessageController(IEditMessageUseCase useCase)
        {
            _useCase = useCase;
        }

        void IOutputPort.Ok(Message message)
        {
            _viewModel = Ok(new MessageModel(message));
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
        public async Task<IActionResult> EditMessage(Guid messageId, string text)
        {
            _useCase.SetOutputPort(this);

            await _useCase.Execute(messageId, text);

            return _viewModel;
        } 
    }
}

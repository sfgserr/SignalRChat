﻿using Application.Services;
using Domain;
using Domain.ValueObjects;

namespace Application.UseCases.SendMessage
{
    public class SendMessageUseCase : ISendMessageUseCase
    {
        private IOutputPort _outputPort;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IMessageRepository _messageRepository;

        public SendMessageUseCase(IUnitOfWork unitOfWork, IMessageRepository messageRepository, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _messageRepository = messageRepository;
            _userService = userService;

            _outputPort = new SendMessagePresenter();
        }

        public async Task Execute(string userReceiverId, string text)
        {
            string userSenderId = _userService.GetCurrentUserId();

            Message message = new Message(new MessageId(Guid.NewGuid()), userSenderId, userReceiverId, text, DateTime.Now);

            await SendMessage(message);

            _outputPort.Ok(message);
        }

        private async Task SendMessage(Message message)
        {
            await _messageRepository.Add(message);

            await _unitOfWork.Save();
        }

        public void SetOutputPort(IOutputPort outputPort)
        {
            _outputPort = outputPort;
        }
    }
}

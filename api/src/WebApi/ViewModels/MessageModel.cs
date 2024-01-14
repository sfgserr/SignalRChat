using Domain;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels
{
    public class MessageModel
    {
        public MessageModel(Message message)
        {
            Id = message.Id.Id;
            SenderId = message.ExternalUserSenderId;
            ReceiverId = message.ExternalUserReceiverId;
            Text = message.Text;
            SentTime = message.SentTime;
        }

        [Required]
        public Guid Id { get; set; }

        [Required]
        public string SenderId { get; set; }

        [Required]
        public string ReceiverId { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime SentTime { get; set; }  
    }
}

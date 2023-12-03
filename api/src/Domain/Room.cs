using Domain.Messages;
using Domain.ValueObjects;

namespace Domain
{
    public class Room
    {
        public RoomId Id { get; }
        public List<Message> Messages { get; } = new List<Message>();
    }
}

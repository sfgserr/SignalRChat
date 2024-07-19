using System.Collections.Concurrent;

namespace WebApi.Configuration.Messaging
{
    public class ConnectionMapper
    {
        private static readonly ConcurrentDictionary<Guid, List<string>> _ids = [];

        public static List<string> GetConnections(Guid id)
        {
            return _ids[id];
        }

        public static void AddConnection(Guid identityId, string connectionId)
        {
            _ids[identityId].Add(connectionId);
        }

        public static void RemoveConnection(Guid identityId, string connectionId)
        {
            _ids[identityId].Remove(connectionId);
        }
    }
}

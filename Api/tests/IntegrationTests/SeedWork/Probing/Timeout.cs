
namespace IntegrationTests.SeedWork.Testing
{
    public class Timeout
    {
        private readonly DateTime _endTime;

        public Timeout(int timeoutMillis)
        {
            _endTime = DateTime.Now.AddMilliseconds(timeoutMillis);
        }

        public bool HasTimeout()
        {
            return DateTime.Now > _endTime;
        }
    }
}

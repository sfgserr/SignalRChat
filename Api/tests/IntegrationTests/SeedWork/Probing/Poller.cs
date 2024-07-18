using IntegrationTests.SeedWork.Probing;

namespace IntegrationTests.SeedWork.Testing
{
    public class Poller(int timeoutMillis)
    {
        private readonly int _timeoutMillis = timeoutMillis;

        public async Task CheckAsync(IProbe test)
        {
            var timeout = new Timeout(_timeoutMillis);

            while (!test.IsSatisfied())
            {
                if (timeout.HasTimeout())
                {
                    throw new AssertException(DescribeFailureTo(test));
                }

                await test.SampleAsync();
            }
        }

        private string DescribeFailureTo(IProbe test)
        {
            return test.DescribeFailureTo();
        }
    }
}

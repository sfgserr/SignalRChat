
namespace IntegrationTests.SeedWork
{
    public class TestResult
    {
        public TestResult()
        {
            IsSuccessfully = true;
        }

        public TestResult(string error)
        {
            IsSuccessfully = false;
            Error = error;
        }

        public bool IsSuccessfully { get; }

        public string Error { get; } = string.Empty;
    }
}

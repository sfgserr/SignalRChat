
namespace IntegrationTests.SeedWork.Testing
{
    public interface IProbe
    {
        bool IsSatisfied();

        Task SampleAsync();

        string DescribeFailureTo();
    }
}

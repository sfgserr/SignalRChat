
namespace UnitTests.DeleteMessage
{
    public class InvalidDataSetup : TheoryData<Guid>
    {
        public InvalidDataSetup()
        {
            Add(Guid.Empty);
        }
    }
}

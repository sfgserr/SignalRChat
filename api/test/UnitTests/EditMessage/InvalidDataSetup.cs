
namespace UnitTests.EditMessage
{
    public class InvalidDataSetup : TheoryData<Guid, string>
    {
        public InvalidDataSetup()
        {
            Add(Guid.Empty, "Hello");
            Add(Guid.NewGuid(), "");
        }
    }
}

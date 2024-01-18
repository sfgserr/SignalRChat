using Infrastructure.Data;

namespace UnitTests.EditMessage
{
    public class ValidDataSetup : TheoryData<Guid, string>
    {
        public ValidDataSetup() 
        {
            Add(SeedData.DefaultMessageId.Id, "Hello");
        }
    }
}

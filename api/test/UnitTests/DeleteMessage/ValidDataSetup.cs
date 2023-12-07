using Infrastructure.Data;

namespace UnitTests.DeleteMessage
{
    public class ValidDataSetup : TheoryData<Guid>
    {
        public ValidDataSetup()
        {
            Add(SeedData.DefaultMessageId.Id);
        } 
    }
}

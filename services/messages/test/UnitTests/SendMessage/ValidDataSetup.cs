
namespace UnitTests.SendMessage
{
    internal sealed class ValidDataSetup : TheoryData<string, string, string>
    {
        public ValidDataSetup()
        {
            Add("aaaa-bbbb-cccc-dddd", "aaaa-bbbb-cccc-dddd", "Hello");
            Add("dddd-cccc-bbbb-aaaa", "dddd-cccc-bbbb-aaaa", "Bye");
            Add("1111-2222-3333-4444", "1111-2222-3333-4444", "How are you doing?");
        }
    }
}

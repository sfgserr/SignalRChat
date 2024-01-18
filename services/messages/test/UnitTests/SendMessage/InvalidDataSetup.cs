
namespace UnitTests.SendMessage
{
    internal sealed class InvalidDataSetup : TheoryData<string, string, string>
    {
        public InvalidDataSetup()
        {
            Add("", "aaaa-bbbb-cccc-dddd", null);
            Add("dddd-cccc-bbbb-aaaa", string.Empty, "Bye");
            Add("1111-2222-3333-4444", " ", "How are you doing?");
        }
    }
}

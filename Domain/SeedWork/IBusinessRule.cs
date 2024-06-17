
namespace Domain.SeedWork
{
    public interface IBusinessRule
    {
        bool IsBroken { get; }

        string Message { get; }
    }
}

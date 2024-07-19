
namespace Domain.Users
{
    public interface IUsersCounter
    {
        int GetUsersCountWithSameLogin(string login);
    }
}

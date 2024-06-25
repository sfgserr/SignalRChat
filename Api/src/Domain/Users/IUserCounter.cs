
namespace Domain.Users
{
    public interface IUserCounter
    {
        int GetUsersCountWithSameLogin(string login);
    }
}

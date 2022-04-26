using EntityLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface IUserService : IBaseService<User>
    {
        User GetUserByName(string username);
        bool ChangePassword(int id, string password);
    }
}

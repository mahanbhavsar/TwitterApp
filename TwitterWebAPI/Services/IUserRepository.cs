using TwitterWebAPI.Models;

namespace TwitterWebAPI.Services
{
    public interface IUserRepository
    {
        public User RegisterUser(User user);
        public bool Login(string username, string password);
        public User ResetPassword(User user, string userName);
    }
}

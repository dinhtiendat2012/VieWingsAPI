using VieWingsAPI.Model;

namespace VieWingsAPI.Repository
{
    public interface IUserDAO
    {
        public List<User> GetUsers();
    }
}

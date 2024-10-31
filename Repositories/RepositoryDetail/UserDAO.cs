using VieWingsAPI.Model;
using VieWingsAPI.Repositories;

namespace VieWingsAPI.Repository.RepositoryDetail
{
    public class UserDAO
    {
        private readonly DataContext context;
        public UserDAO(DataContext _context) { 
            this.context = _context;
        }

        public List<User> GetUsers()
        {
            return context.User.ToList();
        }
        public void AddUser(User user)
        {
            context.User.Add(user);
            context.SaveChanges();
        }
    }
}

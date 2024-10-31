using VieWingsAPI.Model;

namespace VieWingsAPI.Service
{
    public interface IUserService
    {
        public User? GetUserExisted(string email, string password);
        public User? GetUserByEmail(string? email);
        public List<User> GetFriendsOfUserId(int userId);
        public string? GetEmailFromToken(HttpContext httpContext);
        public string SendEmailToToken(string email);
    }
}

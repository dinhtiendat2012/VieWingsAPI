using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VieWingsAPI.Model;
using VieWingsAPI.Repository;
using VieWingsAPI.Repository.RepositoryDetail;

namespace VieWingsAPI.Service.ServiceDetail
{
    public class UserService : IUserService
    {

        private readonly Validation val;
        int tokenTime = 2;//1 day
        private readonly UserDAO userDAO;

        public UserService(UserDAO _userDAO, Validation _val)
        {
            userDAO = _userDAO ;
            val = _val;
        }

        public User? GetUserExisted(string email, string password)
        {
            
            if (email == null || password == null || email == "" || password == "")
            {
                return null;
            }
            for (int i = 0; i < userDAO.GetUsers().Count; i++)
            {
                if (email.Equals(userDAO.GetUsers()[i].Email) && password.Equals(userDAO.GetUsers()[i].Password))
                {
                    User user = userDAO.GetUsers()[i];
                    return user;
                }
            }

            return null;
        }
        public User? GetUserByEmail(string? email)
        {
            if (!val.IsValidEmail(email) || email == null)
            {
                return null;
            }
            else
            {
                foreach (User u in userDAO.GetUsers())
                {
                    if (email.Equals(u.Email))
                    {
                        return u;
                    }
                }
                return null;
            }

        }
        public List<User> GetFriendsOfUserId(int userId)
        {
            List<User> friendList = [];
            RequestFriendDAO requestFriendDAO = new();

            List<User> userList = userDAO.GetUsers();
            List<RequestFriend> reqFriends = requestFriendDAO.GetRequestFriendsAccessed();


            foreach (RequestFriend rf in reqFriends)
            {
                if (rf.UserId == userId)
                {
                    foreach (User user in userList)
                    {
                        if (rf.FriendId == user.UserId)
                        {
                            friendList.Add(user);
                        }
                    }

                }
            }


            return friendList;
        }
        public string? GetEmailFromToken(HttpContext httpContext)
        {
            var jwtToken = httpContext.Request.Headers.Authorization.ToString().Replace("Bearer ", "");

            if (jwtToken == null || jwtToken == "")
            {
                return jwtToken;
            }
            try
            {

                var tokenHandler = new JwtSecurityTokenHandler();
                // Giải mã token
                var token = tokenHandler.ReadJwtToken(jwtToken);

                // Lấy claim từ token (lấy Email)
                var email = token.Claims.First(claim => claim.Type == "email").Value;
                if (email == null)
                {
                    return null; // Không tìm thấy email trong token
                }
                // Trả về thông tin email
                return email;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi giải mã token: " + ex.Message);
                return null;
            }

        }

        public string SendEmailToToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("dinhtiendat20122002chuvanandongkinhlangsonvietnam"); // Cùng key như đã sử dụng trong cấu hình
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new(ClaimTypes.Email,email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(tokenTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);


            return tokenString;
        }

        public User GetUserByUserId(int userId)
        {
            foreach(User u in userDAO.GetUsers())
            {
                if(u.UserId == userId)
                {
                    return u;
                }
            }
            return new User();
        }
    }
}

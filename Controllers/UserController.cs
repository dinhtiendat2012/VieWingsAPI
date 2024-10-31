using Microsoft.AspNetCore.Mvc;
using VieWingsAPI.Model;
using VieWingsAPI.Repository.RepositoryDetail;
using VieWingsAPI.Service.ServiceDetail;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VieWingsAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;
        private readonly UserDAO userDAO;
        public UserController(UserService _userService, UserDAO _userDAO)
        {
            this.userService = _userService;
            this.userDAO = _userDAO;
        }

        // GET api/<UserController>/5
        [HttpGet("{userId}")]
        public User? Get(int userId)
        {
            try {
                User u = new User();
                u = userService.GetUserByUserId(userId);
                return u;
            }catch (Exception)
            {
                return null;
            }
            
        }
        // GET api/<UserController>/5
        [HttpGet("email")]
        public User? Get(string email)
        {
            try
            {
                User? u = new User();
                u = userService.GetUserByEmail(email);
                return u;
            }
            catch (Exception)
            {
                return null;
            }

        }

        // POST api/user/add
        [HttpPost("add")]
        public int? Post([FromBody] User user)
        {
            try
            {
                userDAO.AddUser(user);
                User? u = userService.GetUserByEmail(user.Email);
                return u.UserId;
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

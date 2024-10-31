
using Microsoft.AspNetCore.Mvc;
using VieWingsAPI.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Linq;
using VieWingsAPI.Service;
using VieWingsAPI.Service.ServiceDetail;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VieWingsAPI.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserService userService ;
        private readonly Validation val;

        public LoginController(UserService _userService, Validation _val)
        {
            this.userService = _userService;
            this.val = _val;
        }   
        // POST api/<LoginController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {       
            if (!val.IsValidEmail(user.Email) || !val.IsValidPassword(user.Password))
            {
                return Unauthorized();
            }
            // Kiểm tra thông tin đăng nhập hợp lệ (kiểm tra từ database)
            User? u = userService.GetUserExisted(user.Email, user.Password);
            if ( u != null)
            {  
                userService.GetUserByUserId(u.UserId).Status = "online";
                var tokenString = userService.SendEmailToToken(u.Email);
                // Trả về token cho client
                return Ok(new { Token = tokenString });
            }
            return Unauthorized();

        }

        // GET: api/login
        [HttpGet]
        public User? Get()
        {

            //Lay User da dang nhap luu trong access token
            User? user = userService.GetUserByEmail(userService.GetEmailFromToken(HttpContext));
           
            return user;
        }
        
        // GET: api/login
        [HttpGet("/login")]
        public string? Test2()
        {
            return HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        }
        

        


        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

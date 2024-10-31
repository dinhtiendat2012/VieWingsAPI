using Microsoft.AspNetCore.Mvc;
using VieWingsAPI.Model;
using VieWingsAPI.Repository.RepositoryDetail;
using VieWingsAPI.Service;
using VieWingsAPI.Service.ServiceDetail;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VieWingsAPI.Controllers
{
    [Route("api/profile")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ProfileDAO profileDAO;
        private readonly ProfileService profileService ;
        private readonly UserService userService;
        public ProfileController(ProfileService _profileService, UserService _userService, ProfileDAO _profileDAO)
        {
            this.profileService = _profileService;
            this.userService = _userService;
            this.profileDAO = _profileDAO;
        }

        // GET: api/<ProfileController>
        [HttpGet()]
        public Profile? Get()
        {
            try { 
                User? user = userService.GetUserByEmail(userService.GetEmailFromToken(HttpContext));
                if (user == null) { throw new Exception(); }
                else { 
                    Profile? p = new Profile(user.UserId);
                    p = profileService.GetProfileByUserId(user.UserId);
                    return p;
                }
            }catch (Exception) {
                return null;
            }
            
        }

        // POST api/<ProfileController>
        [HttpPost("user/{userId}")]
        public Profile? Post( int userId)
        {
            return profileService.GetProfileByUserId(userId);
        }
        // POST api/<ProfileController>
        [HttpPost("add")]
        public void Post([FromBody]Profile profile)
        {
            profileDAO.AddProfile(profile);
            return;
        }

        // PUT api/<ProfileController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProfileController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

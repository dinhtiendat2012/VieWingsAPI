using Microsoft.AspNetCore.Mvc;
using VieWingsAPI.Model;
using VieWingsAPI.Repositories;
using VieWingsAPI.Repository.RepositoryDetail;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VieWingsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly DataContext dataContext;
        private readonly RoleDAO roleDAO;
        private readonly PostDAO postDAO;
        public  TestController(RoleDAO _r, PostDAO _postDAO, DataContext _dataContext)
       {
            roleDAO = _r;
            dataContext = _dataContext;
            postDAO = _postDAO;
        }
        
        // GET: api/<TestController>
        [HttpGet]
        public List<Comment> Get()
        {
            Comment comment = new Comment(0,2,1 ,"Chao tat ca", DateTime.Now.ToLocalTime(), null,0);
            dataContext.Comment.Add(comment);
            dataContext.SaveChanges();
            return dataContext.Comment.ToList() ;
        }

        // GET api/<TestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TestController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

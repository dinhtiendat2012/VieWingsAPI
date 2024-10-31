using Microsoft.AspNetCore.Mvc;
using VieWingsAPI.Model;
using VieWingsAPI.Repository.RepositoryDetail;
using VieWingsAPI.Service.ServiceDetail;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VieWingsAPI.Controllers
{
    [Route("api/cmt")]
    [ApiController]
    public class CommentController : ControllerBase
    { 
        private readonly CommentDAO commentDAO;
        private readonly CommentService commentService;
        public CommentController(CommentService _commentService, CommentDAO _commentDAO)
        {
            this.commentService = _commentService;
            this.commentDAO = _commentDAO;
        }
        // GET api/<CommentController>/5
        [HttpGet("{postId}")]
        public List<Comment>? Get(int postId)
        {
            try { 
                List<Comment> cmts = commentService.GetCommentByPostId(postId);
                return cmts;
            }
            catch {
                return null;
            }
            
        }

        // POST api/<CommentController>
        [HttpPost("add")]
        public void Post([FromBody] Comment cmt)
        {
            try {
                Comment c = new Comment(0,cmt.PostId, cmt.UserId, cmt.Content, cmt.CmtDate.ToLocalTime(), cmt.ReplyByCmtId, cmt.Level);
                commentDAO.AddComment(c);
                return;
            } catch (Exception){
                return;
            }
        }

        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

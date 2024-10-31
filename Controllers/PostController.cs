using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using VieWingsAPI.Model;
using VieWingsAPI.Repository;
using VieWingsAPI.Repository.RepositoryDetail;
using VieWingsAPI.Service;
using VieWingsAPI.Service.ServiceDetail;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VieWingsAPI.Controllers
{  
    [Route("api/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly CommentService commentService;
        private readonly PostDAO postDAO;
        private readonly UserService userService;
        private readonly PostService postService;
        public PostController(PostDAO _postDAO , UserService _userService , PostService _postService, CommentService _commentService) {
            this.postDAO = _postDAO;
            this.userService = _userService;
            this.postService = _postService;
            this.commentService = _commentService;
        }


        //Get tat ca cac post ra bang tin home cho user da luu trong token
        // GET: api/<PostController>
        [HttpGet]
        public List<Post>? Get()
        {
            try
            {
                List<Post> postList = [];
                User? user = userService.GetUserByEmail(userService.GetEmailFromToken(HttpContext)) ?? throw new Exception();
                //Private,Friend Post cua user
                List<Post> privatePosts = postService.GetPrivatePostsByUserId(user.UserId);
                List<Post> friendPosts = postService.GetFriendPostsByUserId(user.UserId);
                //Public Post cua all
                List<Post> publicPosts = postService.GetPublicPosts();
                //Friend Post cua ban be
                List<Post> PostsOfFriend = postService.GetPostsOfFriendsByUserId(user.UserId);
                //Add
                foreach (Post post in privatePosts)
                {
                    postList.Add(post);
                }
                foreach (Post post in friendPosts)
                {
                    postList.Add(post);
                }
                foreach (Post post in publicPosts)
                {
                    postList.Add(post);
                }
                foreach (Post post in PostsOfFriend)
                {
                    postList.Add(post);
                }
                postList = postService.SortPostByNearestTime(postList);

                return postList;

            }
            catch (Exception)
            {
                return null;
            }
            
            
        }

        //Get danh sach post khi user truy cap vao profile người khác
        //=> Public post cua nguoi do / neu da la status == true thi hiện Friend cua nguoi do 
        // GET api/post/5
        [HttpGet("{friendId}")]
        public List<Post> Get(int friendId, User user)
        {  
            RequestFriendDAO rf = new();
            List<Post> posts = [];

            //Post public cua friendId
            List<Post> publicPosts = postService.GetPublicPostsByUserId(friendId);
            foreach (Post post in publicPosts)
            {
                posts.Add(post);
            }
            //Friend cua friendId
            if( rf.isFriend(user.UserId,friendId)) {
                List<Post> friendPosts = postService.GetFriendPostsByUserId(friendId); 
                foreach (Post post in friendPosts)
                {
                    posts.Add(post);
                }
            }
            
            posts = postService.SortPostByNearestTime(posts);
            return posts;
        }
        //get tat ca bai viet cua toi
        // GET api/<PostController>/5
        [HttpGet("me")]
        public List<Post>? GetMe()
        {
            try {
                User? user = userService.GetUserByEmail(userService.GetEmailFromToken(HttpContext));
                if(user == null) { throw new Exception(); }
                List<Post> posts = postService.GetPostsByUserId(user.UserId);
                posts = postService.SortPostByNearestTime(posts);
                return posts;
            }catch(Exception) {
                Console.WriteLine("API getpost me error");
                return null; } 
            
        }

            // POST api/<PostController>
            [HttpPost("add")] 
        public IActionResult Post([FromBody] Post post)
        {
            try { 
                Post p = new Post(post.UserId,post.Content, post.PostDate.ToLocalTime() , post.LinkImage,post.LinkFile,post.Permission,post.ShareByPostId);
                postDAO.AddPost(post);
                return Ok();
            }catch(Exception) {
                return BadRequest();
            }
                 
            
        }

        // POST api/<PostController>
        [HttpPost("delete/{postId}")]
        public IActionResult Post( int postId)
        {
            try
            {
                commentService.DeleteAllCommentByPostId(postId);
                postService.DeletePostByPostId(postId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }


        }

        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

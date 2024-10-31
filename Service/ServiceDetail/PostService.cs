using VieWingsAPI.Model;
using VieWingsAPI.Repository;
using VieWingsAPI.Repository.RepositoryDetail;

namespace VieWingsAPI.Service.ServiceDetail
{
    public class PostService
    {
        readonly PostDAO postDAO;
        readonly UserService userService;
        public PostService(PostDAO postDAO, UserService userService)
        {
            this.postDAO = postDAO;
            this.userService = userService;
        }

        public List<Post> GetPublicPosts()
        {
            List<Post> postList = [];
            List<Post> posts = postDAO.GetPosts();
            foreach (Post post in posts)
            {
                if (post.Permission == "Public")
                {
                    postList.Add(post);
                }
            }

            return postList;
        }
        public List<Post> GetPrivatePostsByUserId(int userId)
        {
            List<Post> postList = [];
            List<Post> posts = postDAO.GetPosts();
            foreach (Post post in posts)
            {
                if (post.UserId == userId && post.Permission == "Private")
                {
                    postList.Add(post);
                }
            }
            return postList;
        }
        public List<Post> GetPublicPostsByUserId(int userId)
        {
            List<Post> posts = postDAO.GetPosts();
            List<Post> postList = [];
            foreach (Post post in posts)
            {
                if (post.UserId == userId && post.Permission == "Public")
                {
                    postList.Add(post);
                }
            }


            return postList;
        }

        public List<Post> GetFriendPostsByUserId(int userId)
        {
            List<Post> posts = postDAO.GetPosts();
            List<Post> postList = [];
            foreach (Post post in posts)
            {
                if (post.UserId == userId && post.Permission == "Friend")
                {
                    postList.Add(post);
                }
            }
            return postList;
        }
        public List<Post> SortPostByNearestTime(List<Post> postUnSorted)
        {
            return postUnSorted.OrderByDescending(post => post.PostDate).ToList();
        }

        //Tat ca cac bai viet cua tat ca ban be cua nguoi dung userId
        public List<Post> GetPostsOfFriendsByUserId(int userId)
        {
            List<Post> posts = postDAO.GetPosts();
            List<User> friends = userService.GetFriendsOfUserId(userId);
            List<Post> postList = [];
            foreach (User friend in friends)
            {
                foreach (Post post in posts)
                {   //Post cua ban be va o che do ban be
                    if (friend.UserId == post.UserId && post.Permission == "Friend")
                    {
                        postList.Add(post);
                    }
                }
            }
            return postList;
        }
        public List<Post> GetPostsByUserId(int userId)
        {
            List<Post> posts = new List<Post>();
            foreach (Post p in postDAO.GetPosts())
            {
                if (p.UserId == userId)
                {
                    posts.Add(p);
                }
            }
            return posts;
        }
        public Post? GetPostByPostId(int postId)
        {
            foreach (Post post in postDAO.GetPosts())
            {
                if (post.PostId == postId)
                {
                    return post;
                }
            }
            return null;
        }
        public void DeletePostByPostId(int postId)
        {
            foreach(Post post in postDAO.GetPosts())
            {
                if(post.PostId == postId)
                {
                    postDAO.DeletePost(post);
                    return;
                }
            }
            return;
        }
    }
}

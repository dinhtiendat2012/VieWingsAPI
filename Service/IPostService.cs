using VieWingsAPI.Model;

namespace VieWingsAPI.Service
{
    public interface IPostService
    {
        public List<Post> GetPublicPosts();
        public List<Post> GetPrivatePostsByUserId(int userId);
        public List<Post> GetPublicPostsByUserId(int userId);

        public List<Post> GetFriendPostsByUserId(int userId);
        public List<Post> GetPostsOfFriendsByUserId(int userId);
        public List<Post> GetPostsByUserId(int userId);
        public List<Post> SortPostByNearestTime(List<Post> postUnSorted);
    }
}



using VieWingsAPI.Model;

namespace VieWingsAPI.Repository
{
    public interface IPostDAO
    {
        public List<Post> GetPosts();
        public void AddPost(Post post);

    }
}

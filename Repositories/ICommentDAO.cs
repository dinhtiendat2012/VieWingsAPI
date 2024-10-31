using VieWingsAPI.Model;

namespace VieWingsAPI.Repository
{
    public interface ICommentDAO
    {
        public List<Comment> GetComments();
    }
}

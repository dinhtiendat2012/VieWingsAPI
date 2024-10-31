using VieWingsAPI.Model;

namespace VieWingsAPI.Service
{
    public interface ICommentService
    {
        List<Comment> GetCommentByPostId(int id);
    }
}
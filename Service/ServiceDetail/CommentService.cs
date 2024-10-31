

using VieWingsAPI.Model;
using VieWingsAPI.Repositories;
using VieWingsAPI.Repository.RepositoryDetail;

namespace VieWingsAPI.Service.ServiceDetail
{
    public class CommentService : ICommentService
    {
        private readonly DataContext context;
        private readonly CommentDAO commentDAO;
        public CommentService(CommentDAO _commentDAO, DataContext context) { 
            this.commentDAO = _commentDAO;
            this.context = context;
        }
        public List<Comment> GetCommentByPostId(int postId)
        {
            List<Comment> comments = new List<Comment>();
            foreach(Comment cmt in commentDAO.GetComments())
            {
                if(cmt.PostId == postId)
                {
                    comments.Add(cmt);
                }
            }


            return comments ;
        }
        public void DeleteAllCommentByPostId(int postId)
        {
            RemoveAllCmtByLevelAndPostId(3,postId);
            RemoveAllCmtByLevelAndPostId(2,postId);
            RemoveAllCmtByLevelAndPostId(1,postId);
            return;
        }

        private void RemoveAllCmtByLevelAndPostId(int level,int postId)
        {
            foreach(Comment cmt in commentDAO.GetComments())
            {
                if(cmt.PostId == postId && cmt.Level == level)
                {
                    context.Remove(cmt);
                }
            }
            context.SaveChanges();
            return;
        }

    }
}

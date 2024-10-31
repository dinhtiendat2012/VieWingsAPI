using Microsoft.Extensions.Hosting;
using VieWingsAPI.Model;
using VieWingsAPI.Repositories;

namespace VieWingsAPI.Repository.RepositoryDetail
{
    public class CommentDAO : ICommentDAO
    {
        private readonly DataContext context;
        public CommentDAO(DataContext _context)
        {
            this.context = _context;
        }
        public List<Comment> GetComments() {  
            
            return context.Comment.ToList();  
        
        }
        public void AddComment(Comment comment) {
                context.Comment.Add(comment);
                context.SaveChanges();
            
        }

    }
}

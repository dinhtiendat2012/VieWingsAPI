using VieWingsAPI.Model;
using VieWingsAPI.Repositories;
using VieWingsAPI.Service.ServiceDetail;

namespace VieWingsAPI.Repository.RepositoryDetail
{
    public class PostDAO
    {   
        private readonly DataContext context;

        public PostDAO(DataContext _context)
        {
            this.context = _context;
        }
        public List<Post> GetPosts()
        {
            return context.Post.ToList();
        }
        public void AddPost(Post post)
        {
             context.Post.Add(post);
             context.SaveChanges();
                
        }
        public void DeletePost(Post post)
        {
            
            context.Post.Remove(post);
            context.SaveChanges();
            return ;
           
        }

    }
}

using VieWingsAPI.Model;
using VieWingsAPI.Repositories;

namespace VieWingsAPI.Repository.RepositoryDetail
{
    public class ProfileDAO : IProfileDAO
    {
        private readonly DataContext context;
        public ProfileDAO( DataContext _context ) {
            this.context = _context;
        }

        public List<Profile> GetProfiles()
        {
            return context.Profile.ToList();
        }

        public void AddProfile( Profile profile )
        {
            context.Profile.Add( profile );
            context.SaveChanges();
        }
    }
}
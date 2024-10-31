using VieWingsAPI.Model;
using VieWingsAPI.Repository;
using VieWingsAPI.Repository.RepositoryDetail;

namespace VieWingsAPI.Service.ServiceDetail
{
    public class ProfileService : IProfileService
    {
        private readonly ProfileDAO profileDAO;
        public ProfileService(ProfileDAO _profileDAO)
        {
            this.profileDAO = _profileDAO;
        }
        public Profile? GetProfileByUserId(int userId)
        {

            foreach (Profile p in profileDAO.GetProfiles())
            {
                if (p.UserId.Equals(userId))
                {
                    return p;
                }
            }
            return null;
        }
    }
}

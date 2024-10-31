using VieWingsAPI.Model;

namespace VieWingsAPI.Service
{
    public interface IProfileService
    {
        public Profile? GetProfileByUserId(int userId);
    }
}

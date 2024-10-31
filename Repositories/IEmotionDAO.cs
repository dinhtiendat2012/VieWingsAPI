using VieWingsAPI.Model;

namespace VieWingsAPI.Repository
{
    public interface IEmotionDAO
    {
        public List<Emotion> GetEmotions();
    }
}

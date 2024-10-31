using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VieWingsAPI.Model
{
    public class EmotionOfPost
    {
        public EmotionOfPost(int postId, int userId, int eId)
        {
            this.PostId = postId;
            this.UserId = userId;
            this.EId = eId;
        }
        [Key]
        public int PostId { get; set; }
        public int UserId { get; set; }
        public int EId { get; set; }
    }
}

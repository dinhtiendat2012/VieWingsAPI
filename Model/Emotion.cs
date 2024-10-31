using System.ComponentModel.DataAnnotations;

namespace VieWingsAPI.Model
{
    public class Emotion
    {
        public Emotion(int eId,string name , string linkImage) {
            this.EId = eId;
            this.Name = name;
            this.LinkImage = linkImage;
        }
        [Key]
        public int EId { get; set; }
        public string Name { get; set; }
        public string LinkImage { get; set; }
    }
}

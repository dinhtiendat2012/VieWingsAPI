using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VieWingsAPI.Model
{
    
    public class EmotionOfComment
    { 
        public EmotionOfComment(int cmtId , int userId,int eId) {
            this.CmtId = cmtId;
            this.UserId = userId;
            this.EId = eId;
        }
        [Key]
        public int CmtId { get; set; }
        public int UserId { get; set; }
        public int EId { get; set; }
       
    }
}

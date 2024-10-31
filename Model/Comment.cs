using System.ComponentModel.DataAnnotations;

namespace VieWingsAPI.Model
{
    public class Comment
    {
        public Comment() {
            CmtId = 0;
            UserId = 0;
            PostId = 0;
            Content = "";
            CmtDate = DateTime.Now.ToLocalTime();
            ReplyByCmtId = null;
            Level = 0;
        }
        public Comment(int cmtId, int postId, int userId, string content, DateTime cmtDate, int? replyByCmtId,int level)
        {
            this.CmtId = cmtId;
            this.PostId = postId;
            this.UserId = userId;
            this.Content = content;
            this.Level = level;
            this.ReplyByCmtId = replyByCmtId;
            this.CmtDate = cmtDate;
        }
        [Key]
        public int CmtId { get; set; } 
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }

        public DateTime CmtDate { get; set; }
        public int? ReplyByCmtId { get; set; }
        public int Level { get; set; }
    }
}

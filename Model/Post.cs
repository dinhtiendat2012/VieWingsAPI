using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security;
using System.Text.Json.Serialization;

namespace VieWingsAPI.Model
{
    public class Post
    {
        public Post()
        {
            UserId = 0;
            PostDate = DateTime.Now;
            Permission = "";

        }
        public Post( int userId, DateTime postDate, string permission) {
           
            UserId = userId;
            PostDate = postDate;
            Permission = permission;
        }
        
        public Post(int userId, string? content,DateTime postDate , string? linkImage , string? linkFile, string permission,int? shareByUserId) {
           
            this.UserId = userId;
            this.Content = content;
            this.PostDate = postDate;
            this.LinkImage = linkImage;
            this.LinkFile = linkFile;
            this.Permission = permission;
            this.ShareByPostId = shareByUserId;
        }
        public Post(int postId, int userId, string? content, DateTime postDate, string? linkImage, string? linkFile, string permission, int? shareByPostId)
        {
            PostId = postId;
            UserId = userId;
            PostDate = postDate;
            LinkImage = linkImage;
            LinkFile = linkFile;
            Content = content;
            Permission = permission;
            ShareByPostId = shareByPostId;
        }
      
        [Key]
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string? Content { get; set; }
        public DateTime PostDate { get; set; }
        public string? LinkImage { get; set; }
        public string? LinkFile { get; set; }
        public string Permission { get; set; }
        public int? ShareByPostId { get; set; }
    }
}

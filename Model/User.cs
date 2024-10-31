
using System.ComponentModel.DataAnnotations;

namespace VieWingsAPI.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public int RoleId { get; set; }
        public User() {
            this.UserId = 0;
            this.Email = "";
            this.Password = "";
            this.Status = "";
            this.RoleId = 2;
        }
        public User( string email, string password)
        {
            this.Email = email;
            this.Password = password;
            this.RoleId = 2;
            this.Status = "Offline";
        }
        public User(int userId, string email, string password, string status, int roleId)
        {
            this.UserId = userId;
            this.Email = email;
            this.Password = password;
            this.RoleId = roleId;
            this.Status = status;
        }
    }
}

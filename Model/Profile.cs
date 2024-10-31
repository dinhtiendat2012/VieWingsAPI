using System.ComponentModel.DataAnnotations;
using VieWingsAPI.Service.ServiceDetail;

namespace VieWingsAPI.Model
{
    public class Profile
    {  
        public Profile() {
            this.ProfileId = 0;
            this.Name = "Your-name";
            this.UserId = 0;
            this.Phone = "";
            this.Dob = null;
            this.Address = null;
        }
        public Profile( int userId) {
            UserId = userId;
            Name = "Your-name";
        }
        public Profile(int profileId, int userId,string linkAvt,string? name,DateOnly? dob,string? phone, string? address) {
            this.ProfileId = profileId;
            this.UserId = userId;
            this.Name = name;
            this.Dob = dob;
            this.Phone = phone;
            this.Address = address;

        }
        [Key]
        public int ProfileId { get; set; }
        public int UserId { get; set; }
        public string? LinkAvt { get; set; }
        public string? Name { get; set; }
        public DateOnly? Dob { get; set; }
        public string? Phone {  get; set; }
        public string? Address { get; set; }
    }
}

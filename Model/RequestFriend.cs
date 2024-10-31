using System.ComponentModel.DataAnnotations;

namespace VieWingsAPI.Model
{
    public class RequestFriend
    {
        public RequestFriend(int userId , int friendId, bool status) {
            this.FriendId = friendId;
            this.UserId = userId;
            this.Status = status;
        }
        
        public int UserId { get; set; }
        public int FriendId { get; set; }
        public bool Status { get; set; }


    }
}

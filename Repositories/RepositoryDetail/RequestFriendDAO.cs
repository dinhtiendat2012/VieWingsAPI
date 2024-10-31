using VieWingsAPI.Model;

namespace VieWingsAPI.Repository.RepositoryDetail
{
    public class RequestFriendDAO : IRequestFriendDAO
    {
        public RequestFriendDAO() { }

        public List<RequestFriend> GetRequestFriends()
        {
            List<RequestFriend> reqFriends = new List<RequestFriend>();
            reqFriends.Add(new RequestFriend(1, 2, true));
            reqFriends.Add(new RequestFriend(2, 1, true));
            reqFriends.Add(new RequestFriend(2, 3, false));
            reqFriends.Add(new RequestFriend(3, 4, false));
            reqFriends.Add(new RequestFriend(5, 3, false));
            return reqFriends;
        }

        public List<RequestFriend> GetRequestFriendsAccessed()
        {
            List<RequestFriend> reqFriends = new List<RequestFriend>();
            foreach (RequestFriend rf in GetRequestFriends())
            {
                if (rf.Status == true)
                {
                    reqFriends.Add(rf);
                }
            }


            return reqFriends;
        }
        public bool isFriend(int userId1, int userId2)
        {
            foreach (RequestFriend rf in GetRequestFriendsAccessed())
            {
                if (rf.UserId == userId1 && rf.FriendId == userId2)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

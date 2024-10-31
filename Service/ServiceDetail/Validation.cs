using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;
using VieWingsAPI.Repository;
using VieWingsAPI.Repository.RepositoryDetail;

namespace VieWingsAPI.Service.ServiceDetail
{
    public class Validation : IValidation
    {
        private readonly UserDAO userDAO;
        public Validation(UserDAO userDAO)
        {
            this.userDAO = userDAO;
        }
        public bool CheckEmailExisted(string email)
        {
            
            foreach (var u in userDAO.GetUsers())
            {
                if (email.Equals(u.Email))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsValidEmail(string? email)
        {
            if (email == "" || email == null)
            {
                return false;
            }
            else
            {
                string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                return Regex.IsMatch(email, emailPattern);
            }

        }

        public bool IsValidPassword(string password)
        {


            return true;
        }
    }
}

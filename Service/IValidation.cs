namespace VieWingsAPI.Service
{
    public interface IValidation
    {
        public bool CheckEmailExisted(string email);
        public bool IsValidEmail(string? email);
        public bool IsValidPassword(string password);
    }
}

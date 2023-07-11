using Tourism.Entities.Concrete;

namespace Tourism.Business.Authentication
{
    public interface IAuthenticationService
    {
        Task<bool> Register(string firstName, string lastName, string email, string username, string password, string confirmPassword);
        Task<OperatorUser> Login(string username, string password); //in the tutorial there was a Accont instead of a user

    }
}

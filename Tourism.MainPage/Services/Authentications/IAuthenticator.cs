using System.Threading.Tasks;
using Tourism.Entities.Concrete;

namespace Tourism.MainPage.Services.Authentications
{
    public interface IAuthenticator
    {

        OperatorUser CurrentUser { get; }
        bool IsLoggedIn { get; }
        // Task<RegistrationResult>
        Task<bool> Login(string username, string password);
        void Logout();



    }
}

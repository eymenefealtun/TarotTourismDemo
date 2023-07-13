using System;
using System.Threading.Tasks;
using Tourism.Business.Authentication;
using Tourism.Entities.Concrete;

namespace Tourism.MainPage.Services.Authentications
{
    public class Authenticator : IAuthenticator
    {
        private readonly IAuthenticationService _authenticationService;

        public Authenticator(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public OperatorUser CurrentUser { get; private set; }
        public bool IsLoggedIn => CurrentUser != null;

        public async Task<bool> Login(string username, string password)
        {
            bool success = true;
            try
            {
                CurrentUser = await _authenticationService.Login(username, password);
            }
            catch (Exception)
            {
                success = false;
            }
            return success;
        }

        public void Logout()
        {
            CurrentUser = null;
        }


    }
}

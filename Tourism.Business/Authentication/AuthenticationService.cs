using FluentValidation.Validators;
using Microsoft.AspNet.Identity;
using System.Runtime.CompilerServices;
using Tourism.Business.DependencyResolvers.Ninject;
using Tourism.Entities.Concrete;

namespace Tourism.Business.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {


        private readonly IPasswordHasher _passwordHasher;//Asp.Net package downloaded for this
        private IOperatorUserService _operatorUserService;
        public AuthenticationService()
        {
            _passwordHasher = new PasswordHasher();
            _operatorUserService = Instancefactory.GetInstance<IOperatorUserService>();
        }
        public async Task<OperatorUser> Login(string username, string password)
        {
            var user = _operatorUserService.GetByUsername(username);
            PasswordVerificationResult passwordResult = _passwordHasher.VerifyHashedPassword(user.PasswordHash, password);
            if (passwordResult != PasswordVerificationResult.Success)
            {
                throw new Exception("Credentials are wrong");
            }
            return _operatorUserService.GetByUserId(user.Id);
        }

        public async Task<bool> Register(string firstName, string lastName, string email, string username, string password, string confirmPassword)
        {
            bool isSucceed = false;
            if (password == confirmPassword)
            {

                string hashedPassword = _passwordHasher.HashPassword(password);

                OperatorUser operatorUser = new OperatorUser
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    Username = username,
                    PasswordHash = hashedPassword,
                    DateJoined = DateTime.Now
                };
            }


            return isSucceed;
        }



    }
}

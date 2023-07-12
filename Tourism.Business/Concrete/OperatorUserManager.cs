using Tourism.Business.ValidationRules.FluentValidation;
using Tourism.Core.CrossCuttingConcerns.Validation.ValidatorTool;
using Tourism.Entities.Abstract;

namespace Tourism.Entities.Concrete
{
    public class OperatorUserManager : IOperatorUserService
    {
        private IOperatorUserDal _operatorUserDal;
        public OperatorUserManager(IOperatorUserDal operatorUserDal)
        {
            _operatorUserDal = operatorUserDal;
        }

        public OperatorUser Add(OperatorUser operatorUser)
        {
            ValidationTool.FluentValidate(new OperatorUserValidator(), operatorUser);

            return _operatorUserDal.Add(operatorUser);
        }

        public List<OperatorUser> GetAll()
        {
            return _operatorUserDal.GetAll();
        }

        public OperatorUser GetByPassword(string password)
        {
            return _operatorUserDal.Get(x => x.PasswordHash == password);   
        }

        public OperatorUser GetByUserId(int userId)
        {
            return _operatorUserDal.Get(x => x.Id == userId);
        }

        public OperatorUser GetByUsername(string username)
        {
            return _operatorUserDal.Get(x=>x.Username == username);      
        }

        public OperatorUser GetByUsernameAndPassword(string username, string password)
        {
            return _operatorUserDal.GetByUsernameAndPassword(username, password);
        }

        public OperatorUser GetByUsernameSqlRaw(string username)
        {               
            return _operatorUserDal.GetByUsernameSqlRaw(username);
        }

        public OperatorUser Update(OperatorUser operatorUser)
        {
            ValidationTool.FluentValidate(new OperatorUserValidator(), operatorUser);
            return _operatorUserDal.Update(operatorUser);
        }


  




    }


}

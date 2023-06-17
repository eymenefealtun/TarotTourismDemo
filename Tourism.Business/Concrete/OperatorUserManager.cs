using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.DataAccess.Concrete.EntityFramework;

namespace Tourism.Entities.Concrete
{
    public class OperatorUserManager : IOperatorUserService
    {
        private IOperatorUserDal _operatorUserDal;
        public OperatorUserManager(IOperatorUserDal operatorUserDal)
        {
            _operatorUserDal = operatorUserDal;     
        }

        public List<OperatorUser> GetAll()
        {
            return _operatorUserDal.GetAll();
        }

        public OperatorUser GetByUserId(int userId)     
        {
            return _operatorUserDal.Get(x=>x.Id == userId);                 
        }
    }
}

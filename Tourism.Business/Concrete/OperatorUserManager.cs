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



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.DataAccess.Concrete.EntityFramework;

namespace Tourism.Entities.Concrete
{
    public class UserLevelManager : IUserLevelService
    {
        private IUserLevelDal _userLevelDal;
        public UserLevelManager(IUserLevelDal userLevelDal) 
        {
            _userLevelDal = userLevelDal;           
        }

        public List<UserLevel> GetAll()
        {
            return _userLevelDal.GetAll();
        }

    }
}

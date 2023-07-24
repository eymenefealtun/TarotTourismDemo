using Tourism.Business.Abstract;
using Tourism.DataAccess.Abstract;
using Tourism.Entities.Concrete;

namespace Tourism.Business.Concrete
{

    public class RoleManager : IRoleService
    {
        private IRoleDal _roleDal;
        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }
        public Role GetByRoleName(string roleName)
        {
            return _roleDal.Get(x=>x.Name == roleName);             
        }
    }
}

using Tourism.Business.Abstract;
using Tourism.DataAccess.Abstract;
using Tourism.Entities.Concrete;

namespace Tourism.Business.Concrete
{
    public class OperatorUserRoleManager : IOperatorUserRoleService
    {
        private IOperatorUserRoleDal _operatorUserRoleDal;

        public OperatorUserRoleManager(IOperatorUserRoleDal operatorUserRoleDal)
        {
            _operatorUserRoleDal = operatorUserRoleDal;
        }

        public List<OperatorUserRole> BulkDelete(List<OperatorUserRole> roles)
        {
            return _operatorUserRoleDal.BulkDelete(roles);
        }

        public OperatorUserRole Delete(OperatorUserRole operatorUserRole)
        {
            return _operatorUserRoleDal.Delete(operatorUserRole);
        }

        public OperatorUserRole GetByUserIdAndRoleName(int operatorUserId, string roleName)
        {
            return _operatorUserRoleDal.Get(x => x.Roles.Name == roleName && x.OperatorUserId == operatorUserId);
        }

        public List<OperatorUserRole> GetByUserUserId(int operatorUserId)
        {
            return _operatorUserRoleDal.GetByUserUserId(operatorUserId);
        }


    }
}

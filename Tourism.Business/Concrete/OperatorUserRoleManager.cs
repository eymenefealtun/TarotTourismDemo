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

        public List<OperatorUserRole> GetByUserUserId(int operatorUserId)
        {
            return _operatorUserRoleDal.GetByUserUserId(operatorUserId);
        }


    }
}

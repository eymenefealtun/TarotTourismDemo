
using Tourism.Entities.Concrete;

namespace Tourism.Business.Abstract
{
    public interface IOperatorUserRoleService
    {
        List<OperatorUserRole> GetByUserUserId(int operatorUserId);
        //OperatorUserRole GetByRoleName(string roleName);      
    }
}

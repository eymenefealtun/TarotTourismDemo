
using Tourism.Entities.Concrete;

namespace Tourism.Business.Abstract
{
    public interface IOperatorUserRoleService
    {
        List<OperatorUserRole> GetByUserUserId(int operatorUserId);
        OperatorUserRole GetByUserIdAndRoleName(int operatorUserId, string roleName);
        List<OperatorUserRole> BulkDelete(List<OperatorUserRole> roles);
        OperatorUserRole Delete(OperatorUserRole operatorUserRole);
        //OperatorUserRole GetByRoleName(string roleName);      
    }
}

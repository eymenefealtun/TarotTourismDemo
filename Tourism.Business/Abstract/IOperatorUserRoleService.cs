
using Tourism.Entities.Concrete;

namespace Tourism.Business.Abstract
{
    public interface IOperatorUserRoleService
    {
        List<OperatorUserRole> GetByUserUserId(int operatorUserId);
        List<OperatorUserRole> BulkDelete(List<OperatorUserRole> roles);                
        //OperatorUserRole GetByRoleName(string roleName);      
    }
}

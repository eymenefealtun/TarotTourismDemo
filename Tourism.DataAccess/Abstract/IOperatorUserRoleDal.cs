using Tourism.Core.DataAccess.EntityFramework.Abstract;
using Tourism.Entities.Concrete;

namespace Tourism.DataAccess.Abstract
{
    public interface IOperatorUserRoleDal : IEntityRepository<OperatorUserRole>
    {
        List<OperatorUserRole> GetByUserUserId(int operatorUserId);
    }
}

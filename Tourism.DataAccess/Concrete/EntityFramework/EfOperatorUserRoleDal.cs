using Microsoft.EntityFrameworkCore;
using Tourism.Core.DataAccess.EntityFramework.Concrete;
using Tourism.DataAccess.Abstract;
using Tourism.Entities.Concrete;

namespace Tourism.DataAccess.Concrete.EntityFramework
{
    public class EfOperatorUserRoleDal : EfEntityRepositoryBase<OperatorUserRole, AppDbContext>, IOperatorUserRoleDal
    {
        public List<OperatorUserRole> GetByUserUserId(int operatorUserId)
        {
            using (var context = new AppDbContext())
            {
                return context.Set<OperatorUserRole>().
                    Include(x => x.Roles).
                    Include(x => x.OperatorUser).
                    Where(x => x.OperatorUserId == operatorUserId).
                    AsNoTracking().
                    ToList();
            }
        }



    }
}

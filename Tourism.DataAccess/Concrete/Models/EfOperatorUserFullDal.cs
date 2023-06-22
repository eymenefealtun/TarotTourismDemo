using Microsoft.EntityFrameworkCore;
using Tourism.DataAccess.Abstract.Models;
using Tourism.DataAccess.Concrete.EntityFramework;
using Tourism.Entities.Models;

namespace Tourism.DataAccess.Concrete.Models
{
    public class EfOperatorUserFullDal : EfEntityRepositoryBase<OperatorUserFull, AppDbContext>, IOperatorUserFullDal
    {
        public List<OperatorUserFull> GetOperatorUsers()
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Set<OperatorUserFull>().FromSqlRaw($"SELECT O.Id 'OperatorUserId',O.Username, O.Password, Op.Name'OperatorName', U.Name'Level' FROM OperatorUsers O JOIN Operators Op ON O.OperatorId = Op.Id JOIN UserLevels U ON U.Id = O.UserLevelId ORDER BY O.Id").AsNoTracking().ToList();
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Tourism.Core.DataAccess.EntityFramework.Concrete;
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
                return context.Set<OperatorUserFull>().FromSqlRaw($"SELECT  o.FirstName,o.LastName,o.Email,O.Username, O.PasswordHash, Op.Name'OperatorName', o.IsActive,O.Id 'OperatorUserId' , o.DateJoined FROM OperatorUsers O JOIN Operators Op ON O.OperatorId = Op.Id ORDER BY O.Id").AsNoTracking().ToList();
            }
        }


    }
}

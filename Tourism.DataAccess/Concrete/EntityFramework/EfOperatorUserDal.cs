using Microsoft.EntityFrameworkCore;
using Tourism.Core.DataAccess.EntityFramework.Concrete;
using Tourism.DataAccess.Concrete.EntityFramework;
using Tourism.Entities.Abstract;

namespace Tourism.Entities.Concrete
{
    public class EfOperatorUserDal : EfEntityRepositoryBase<OperatorUser, AppDbContext>, IOperatorUserDal
    {
        public OperatorUser GetByUsernameAndPassword(string username, string password)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Set<OperatorUser>().FromSqlRaw($"SELECT  * FROM OperatorUsers O WHERE O.Username  COLLATE  SQL_Latin1_General_CP1_CS_AS = '{username}'  AND O.PasswordHash COLLATE  SQL_Latin1_General_CP1_CS_AS  ='{password}' ").AsNoTracking().SingleOrDefault();
            }
        }

        public OperatorUser GetByUsernameSqlRaw(string username)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Set<OperatorUser>().FromSqlRaw($"SELECT  * FROM OperatorUsers O WHERE O.Username  COLLATE  SQL_Latin1_General_CP1_CS_AS = '{username}'").AsNoTracking().SingleOrDefault();
            }
        }

        public OperatorUser GetByPassword(string username)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Set<OperatorUser>().FromSqlRaw($"SELECT  * FROM OperatorUsers O WHERE O.Username  COLLATE  SQL_Latin1_General_CP1_CS_AS = 'SEPET' OR '1' ='1'").AsNoTracking().SingleOrDefault();
            }
        }

    }
}

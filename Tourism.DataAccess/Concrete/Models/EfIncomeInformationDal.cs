using Microsoft.EntityFrameworkCore;
using Tourism.Core.DataAccess.EntityFramework.Concrete;
using Tourism.DataAccess.Abstract.Models;
using Tourism.DataAccess.Concrete.EntityFramework;
using Tourism.Entities.Models;

namespace Tourism.DataAccess.Concrete.Models
{
    public class EfIncomeInformationDal : EfEntityRepositoryBase<IncomeInformation, AppDbContext>, IIncomeInformationDal
    {
        public List<IncomeInformation> GetByOperation(int operationId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Set<IncomeInformation>().FromSqlRaw("SELECT SUM(R.DiscountedPrice) 'TotalIncome' FROM Reservations R JOIN Operations O ON O.Id = R.OperationId WHERE (O.Id = {0} OR O.Id = 0)", operationId).AsNoTracking().ToList();
            }
        }


    }
}
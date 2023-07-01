using Microsoft.EntityFrameworkCore;
using Tourism.Core.DataAccess.EntityFramework.Concrete;
using Tourism.DataAccess.Concrete.EntityFramework;
using Tourism.Entities.Abstract;

namespace Tourism.Entities.Concrete
{
    public class EfCurrencyDal : EfEntityRepositoryBase<Currency, AppDbContext>, ICurrencyDal
    {
        public List<Currency> GetByOperation(int operationId)
        {
            using (AppDbContext context = new AppDbContext())       
            {
                return context.Set<Currency>().FromSqlRaw("SELECT C.Name, C.Id FROM Currencies C JOIN Operations O ON O.CurrencyId = C.Id WHERE O.Id = {0}", operationId).AsNoTracking().ToList();
            }
        }

    }
}

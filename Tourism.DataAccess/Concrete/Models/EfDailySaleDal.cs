using Microsoft.EntityFrameworkCore;
using Tourism.DataAccess.Abstract.Models;
using Tourism.DataAccess.Concrete.EntityFramework;
using Tourism.Entities.Models;

namespace Tourism.DataAccess.Concrete.Models
{
    public class EfDailySaleDal : EfEntityRepositoryBase<DailySale, AppDbContext>, IDailySaleDal
    {
        public List<DailySale> GetDailySale()
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Set<DailySale>().FromSqlRaw(@"SELECT Ops.Name 'Operator' ,A.Name 'Agency',(SELECT CONCAT(o.StartDate,' | ', o.EndDate) )AS Period ,R.ReservationCode, R.Pax, R.Room,R.TotalPrice,O.DocumentCode,C.Name'Currency', Au.Username 'PurchasedBy', R.CreatedDate  FROM Operations O  --R.ReservationCode,R.Pax, R.Room, R.TotalPrice 
JOIN Reservations R ON R.OperationId = O.ID
JOIN OperationPrices Op ON Op.OperationId = O.Id
JOIN OperatorUsers Ou ON Ou.Id = O.CreatedBy
JOIN Operators Ops ON Ops.Id = Ou.OperatorId
JOIN AgencyUsers Au ON Au.Id = R.AgencyUserId
JOIN Agencies A ON A.Id = Au.AgencyId
JOIN Currencies C ON C.Id = O.CurrencyId
ORDER BY R.CreatedDate DESC
").AsNoTracking().ToList();
            }

        }

    }
}

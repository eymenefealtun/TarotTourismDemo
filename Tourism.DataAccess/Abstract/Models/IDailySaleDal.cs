using Tourism.Core.DataAccess.EntityFramework.Abstract;
using Tourism.Entities.Models;

namespace Tourism.DataAccess.Abstract.Models
{
    public interface IDailySaleDal : IEntityRepository<DailySale>
    {
        List<DailySale> GetDailySale();
    }
}

using Tourism.Entities.Models;

namespace Tourism.DataAccess.Abstract.Models
{
    public interface IDailySaleDal : IEntityRepository<DailySale>
    {
        List<DailySale> GetDailySale();
    }
}

using Tourism.Entities.Models;

namespace Tourism.Business.Abstract.Models
{
    public interface IDailySaleService
    {
        List<DailySale> GetDailySale();
    }
}

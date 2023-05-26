using Tourism.Business.Abstract.Models;
using Tourism.DataAccess.Abstract.Models;
using Tourism.Entities.Models;

namespace Tourism.Business.Concrete.Models
{
    public class DailySaleManager : IDailySaleService
    {
        private IDailySaleDal _dailySaleDal;
        public DailySaleManager(IDailySaleDal dailySaleDal)
        {
            _dailySaleDal = dailySaleDal;
        }

        List<DailySale> IDailySaleService.GetDailySale()
        {
            return _dailySaleDal.GetDailySale();
        }
    }
}

using Tourism.Business.Abstract.Models;
using Tourism.DataAccess.Abstract.Models;
using Tourism.DataAccess.Concrete.Models;
using Tourism.Entities.Models;

namespace Tourism.Business.Concrete.Models
{
    public class IncomeInformationManager : IIncomeInformationService       
    {

        private IIncomeInformationDal _incomeInformationDal;
        public IncomeInformationManager(IIncomeInformationDal incomeInformationDal)
        {
            _incomeInformationDal = incomeInformationDal;           
        }

        public List<IncomeInformation> GetByOperation(int operationId)              
        {
            return _incomeInformationDal.GetByOperation(operationId);           
        }


    }
}

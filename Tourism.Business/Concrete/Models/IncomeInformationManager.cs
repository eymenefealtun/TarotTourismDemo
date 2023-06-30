using Tourism.Business.Abstract.Models;
using Tourism.DataAccess.Abstract.Models;
using Tourism.Entities.Models;

namespace Tourism.Business.Concrete.Models
{
    public class IncomeInformationManager : IIncomeInformationService
    {

        private IIncomeInformationDal _incomeInformationDal;
        public IncomeInformation TotalIncomeByFar()
        {
            return _incomeInformationDal.TotalIncomeByFar();
        }

        public IncomeInformationManager(IIncomeInformationDal incomeInformationDal)
        {
            _incomeInformationDal = incomeInformationDal;
        }

        public List<IncomeInformation> GetByOperation(string name)
        {
            return _incomeInformationDal.GetByOperation(name);
        }

        public List<IncomeInformation> NumberOfBedSold(string name)
        {
            return _incomeInformationDal.NumberOfBedSold(name);
        }

        public List<IncomeInformation> TotalIncomeByAgency(string name)
        {
            return _incomeInformationDal.TotalIncomeByAgency(name);
        }

        public List<IncomeInformation> TotalIncomeByAgencyUser(string name)
        {
            return _incomeInformationDal.TotalIncomeByAgencyUser(name);
        }

        public List<IncomeInformation> TotalIncomeByBedType(string name)
        {
            return _incomeInformationDal.TotalIncomeByBedType(name);
        }

        public List<IncomeInformation> TotalIncomeByCurrency(string name)
        {
            return _incomeInformationDal.TotalIncomeByCurrency(name);
        }

   
        public List<IncomeInformation> TotalIncomeByMainCategory(string name)
        {
            return _incomeInformationDal.TotalIncomeByMainCategory(name);
        }

        public List<IncomeInformation> TotalIncomeByOperator(string name)
        {
            return _incomeInformationDal.TotalIncomeByOperator(name);
        }

        public List<IncomeInformation> TotalIncomeByReservation(string name)
        {
            return _incomeInformationDal.TotalIncomeByReservation(name);
        }

        public List<IncomeInformation> TotalIncomeBySubCategory(string name)
        {
            return _incomeInformationDal.TotalIncomeBySubCategory(name);
        }
    }
}

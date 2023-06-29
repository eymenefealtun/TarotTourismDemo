using Tourism.Business.Abstract.Models;
using Tourism.DataAccess.Abstract.Models;
using Tourism.Entities.Concrete;
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

        public IncomeInformation NumberOfBedSold(int bedTypeId)
        {
            return _incomeInformationDal.NumberOfBedSold(bedTypeId);
        }

        public IncomeInformation TotalIncomeByAgency(int agencyId)
        {
            return _incomeInformationDal.TotalIncomeByAgency(agencyId);
        }

        public IncomeInformation TotalIncomeByAgencyUser(int agencyUserId)
        {
            return _incomeInformationDal.TotalIncomeByAgencyUser(agencyUserId);
        }

        public IncomeInformation TotalIncomeByBedType(int bedTypeId)
        {
            return _incomeInformationDal.TotalIncomeByBedType(bedTypeId);
        }

        public IncomeInformation TotalIncomeByCurrency(int currencyId)
        {
            return _incomeInformationDal.TotalIncomeByCurrency(currencyId);         
        }

        public IncomeInformation TotalIncomeByFar()
        {
            return _incomeInformationDal.TotalIncomeByFar();
        }

        public IncomeInformation TotalIncomeByMainCategory(int mainCategoryId)
        {
            return _incomeInformationDal.TotalIncomeByMainCategory(mainCategoryId);
        }

        public IncomeInformation TotalIncomeByOperator(int operatorId)
        {
            return _incomeInformationDal.TotalIncomeByOperator(operatorId);
        }

        public IncomeInformation TotalIncomeByReservation(int reservationId)
        {
            return _incomeInformationDal.TotalIncomeByReservation(reservationId);
        }

        public IncomeInformation TotalIncomeBySubCategory(int subCategoryId)
        {
            return _incomeInformationDal.TotalIncomeBySubCategory(subCategoryId);
        }
    }
}

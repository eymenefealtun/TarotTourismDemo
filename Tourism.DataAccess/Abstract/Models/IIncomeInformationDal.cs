using Tourism.Core.DataAccess.EntityFramework.Abstract;
using Tourism.Entities.Models;

namespace Tourism.DataAccess.Abstract.Models
{
    public interface IIncomeInformationDal : IEntityRepository<IncomeInformation>
    {
        List<IncomeInformation> GetByOperation(int operationId);
        IncomeInformation TotalIncomeByFar();
        IncomeInformation TotalIncomeByMainCategory(int mainCategoryId);
        IncomeInformation TotalIncomeBySubCategory(int subCategoryId);
        IncomeInformation TotalIncomeByReservation(int reservationId);
        IncomeInformation TotalIncomeByAgencyUser(int agencyUserId);
        IncomeInformation TotalIncomeByAgency(int agencyId);
        IncomeInformation TotalIncomeByOperator(int operatorId);
        IncomeInformation TotalIncomeByCurrency(int currencyId);
        IncomeInformation TotalIncomeByBedType(int bedTypeId);
        IncomeInformation NumberOfBedSold(int bedTypeId);

    }
}

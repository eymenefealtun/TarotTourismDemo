using Tourism.Core.DataAccess.EntityFramework.Abstract;
using Tourism.Entities.Models;

namespace Tourism.DataAccess.Abstract.Models
{
    public interface IIncomeInformationDal : IEntityRepository<IncomeInformation>
    {
        //List<IncomeInformation> GetByOperation(int operationId);
        //IncomeInformation TotalIncomeByFar();
        //IncomeInformation TotalIncomeByMainCategory(int mainCategoryId);
        //IncomeInformation TotalIncomeBySubCategory(int subCategoryId);
        //IncomeInformation TotalIncomeByReservation(int reservationId);
        //IncomeInformation TotalIncomeByAgencyUser(int agencyUserId);
        //IncomeInformation TotalIncomeByAgency(int agencyId);
        //IncomeInformation TotalIncomeByOperator(int operatorId);
        //IncomeInformation TotalIncomeByCurrency(int currencyId);
        //IncomeInformation TotalIncomeByBedType(int bedTypeId);
        //IncomeInformation NumberOfBedSold(int bedTypeId);
        IncomeInformation TotalIncomeByFar();
        List<IncomeInformation> GetByOperation(string name);
        List<IncomeInformation> TotalIncomeByMainCategory(string name);
        List<IncomeInformation> TotalIncomeBySubCategory(string name);
        List<IncomeInformation> TotalIncomeByReservation(string name);
        List<IncomeInformation> TotalIncomeByAgencyUser(string name);
        List<IncomeInformation> TotalIncomeByAgency(string name);
        List<IncomeInformation> TotalIncomeByOperator(string name);
        List<IncomeInformation> TotalIncomeByCurrency(string name);
        List<IncomeInformation> TotalIncomeByBedType(string name);
        List<IncomeInformation> NumberOfBedSold(string name);

    }
}

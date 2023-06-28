using Tourism.Entities.Models;

namespace Tourism.Business.Abstract.Models
{
    public interface IIncomeInformationService
    {
        List<IncomeInformation> GetByOperation(int operationId);        


    }
}

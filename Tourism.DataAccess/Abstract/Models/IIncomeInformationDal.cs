using Tourism.Core.DataAccess.EntityFramework.Abstract;
using Tourism.Entities.Models;

namespace Tourism.DataAccess.Abstract.Models
{
    public interface IIncomeInformationDal : IEntityRepository<IncomeInformation>
    {
        List<IncomeInformation> GetByOperation(int operationId);


    }
}

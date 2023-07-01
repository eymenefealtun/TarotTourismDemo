using Tourism.Core.DataAccess.EntityFramework.Abstract;
using Tourism.Entities.Models;

namespace Tourism.DataAccess.Abstract.Models
{
    public interface IOperationMainDal : IEntityRepository<OperationMain>
    {
        List<OperationMain> GetOperationMain();
        List<OperationMain> GetByDocumentCode(string documentCode);

        List<OperationMain> SearchOperationMain(string documentCode, int mainCategoryId, int subCategoryId, DateTime startDate, DateTime endDate, int operatorId, int currencyId, bool isActive);
    }
}

using Tourism.Entities.Models;

namespace Tourism.Business.Abstract.Models
{
    public interface IOperationMainService
    {
        List<OperationMain> GetOperationMain();
        //OperationMain GetByOperationId(int operationId);
        List<OperationMain> SearchOperationMain(string documentCode, int mainCategoryId, int subCategoryId, DateTime startDate, DateTime endDate,int operatorId, int currencyId, bool isActive);
    }
}

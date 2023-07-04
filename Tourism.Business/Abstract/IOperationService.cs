using Tourism.Entities.Concrete;

namespace Tourism.DataAccess.Abstract
{
    public interface IOperationService
    {
        List<Operation> GetAll();
        Operation Add(Operation operation);
        Operation Update(Operation operation);
        Operation GetByOperationId(int operationId);
        List<Operation> BulkInsert(List<Operation> opearationList);
        List<Operation> GetByDocumentCode(string documentCode);
        List<Operation> GetBySubCategory(int subCategoryId);
        List<Operation> GetBySubCategoryAndDocumentCode(string documentCode, int subCategoryId);

    }
}

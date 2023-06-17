using Tourism.Entities.Concrete;
using Tourism.Entities.Models;

namespace Tourism.DataAccess.Abstract
{
    public interface IOperationService
    {
        List<Operation> GetAll();
        Operation Add(Operation operation);
        Operation Update(Operation operation);
        Operation GetByOperationId(int operationId);        

    }
}

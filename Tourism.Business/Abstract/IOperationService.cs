using Tourism.Entities.Concrete;

namespace Tourism.DataAccess.Abstract
{
    public interface IOperationService
    {
        List<Operation> GetAllWithFilter();
        List<Operation> GetAll();
        Operation Add(Operation operation);
        Operation Update(Operation operation);
    }
}

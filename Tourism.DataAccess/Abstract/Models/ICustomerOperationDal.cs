using Tourism.Entities.Models;

namespace Tourism.DataAccess.Abstract.Models
{
    public interface ICustomerOperationDal : IEntityRepository<CustomerOperation>
    {
        List<CustomerOperation> GetCustomerOperation(int operationId, bool isActive);
        List<CustomerOperation> GetCustomerOperationByReservationId(int operationId, int reservationId, bool isActive);
        List<CustomerOperation> SearchCustomerOperation(string name, int operationId, bool isActive);
        List<CustomerOperation> GetCustomers();

    }
}
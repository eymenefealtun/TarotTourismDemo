using Tourism.Entities.Models;

namespace Tourism.Business.Abstract.Models
{
    public interface ICustomerOperationService 
    {                       
        List<CustomerOperation> GetCustomerOperation(int operationId, bool isActive);
        List<CustomerOperation> SearchCustomerOperation(string name, int operationId, bool isActive);
        List<CustomerOperation> GetCustomers();     
        List<CustomerOperation> GetCustomerOperationByReservationId(int operationId, int reservationId, bool isActive);            
        
    }
}
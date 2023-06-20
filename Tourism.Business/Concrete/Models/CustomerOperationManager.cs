using Tourism.Business.Abstract.Models;
using Tourism.DataAccess.Abstract.Models;
using Tourism.Entities.Models;

namespace Tourism.Business.Concrete.Models
{
    public class CustomerOperationManager : ICustomerOperationService
    {
        private ICustomerOperationDal _customerOperationDal;
                
        public CustomerOperationManager(ICustomerOperationDal customerOperationDal)
        {
            _customerOperationDal = customerOperationDal;
        }

        public List<CustomerOperation> GetCustomerOperation(int operationId, bool isActive)
        {
            return _customerOperationDal.GetCustomerOperation(operationId,isActive);
        }
        public List<CustomerOperation> SearchCustomerOperation(string name, int operationId, bool isActive)
        {
            return _customerOperationDal.SearchCustomerOperation(name, operationId,isActive);       
        }

        public List<CustomerOperation> GetCustomers()
        {
            return _customerOperationDal.GetCustomers();
        }

        public List<CustomerOperation> GetCustomerOperationByReservationId(int operationId, int reservationId, bool isActive)
        {
            return _customerOperationDal.GetCustomerOperationByReservationId(operationId, reservationId, isActive);
        }




    }
}

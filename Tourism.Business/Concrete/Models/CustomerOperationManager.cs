using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    
        public List<CustomerOperation> GetCustomerOperation(int operationId)                      
        {
            return _customerOperationDal.GetCustomerOperation(operationId);     
        }
        public List<CustomerOperation> SearchCustomerOperation(string name, int operationId)
        {           
            return _customerOperationDal.SearchCustomerOperation(name, operationId);
        }

        public List<CustomerOperation> GetCustomers()
        {
            return _customerOperationDal.GetCustomers();
        }
    }
}

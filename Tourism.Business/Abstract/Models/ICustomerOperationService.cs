using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Tourism.Entities.Models;

namespace Tourism.Business.Abstract.Models
{
    public interface ICustomerOperationService 
    {                       
        List<CustomerOperation> GetCustomerOperation(int operationId);
        List<CustomerOperation> SearchCustomerOperation(string name, int operationId);
        List<CustomerOperation> GetCustomers();     
    }
}
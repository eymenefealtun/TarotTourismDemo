using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.DataAccess.Concrete.EntityFramework;

namespace Tourism.Entities.Concrete
{
    public class CustomerManager :  ICustomerService
    {
        private ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;            
        }




    }           
}       

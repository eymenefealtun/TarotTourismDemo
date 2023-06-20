using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.DataAccess.Concrete.EntityFramework;

namespace Tourism.Entities.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public List<Customer> BulkUpdate(List<Customer> customer)
        {
            return _customerDal.BulkUpdate(customer);
        }




        //public Customer BulkUpdate(Customer[] customer)
        //{
        //    return _customerDal.BulkUpdate(customer);
        //}

        public List<Customer> GetByRoomId(int roomId)
        {
            return _customerDal.GetAll(x => x.RoomId == roomId);
        }

        public Customer Update(Customer customer)
        {
            return _customerDal.Update(customer);
        }

    }
}

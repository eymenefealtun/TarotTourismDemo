using Microsoft.EntityFrameworkCore;
using Tourism.DataAccess.Concrete.EntityFramework;

namespace Tourism.Entities.Concrete
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, AppDbContext>, ICustomerDal
    {



    }           
}       

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.DataAccess.Abstract;
using Tourism.Entities.Concrete;

namespace Tourism.DataAccess.Concrete.EntityFramework
{
    public class EfOperationDal : EfEntityRepositoryBase<Operation, AppDbContext>, IOperationDal
    {

    }
}

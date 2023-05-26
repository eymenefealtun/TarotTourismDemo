using Microsoft.EntityFrameworkCore;
using Tourism.DataAccess.Abstract.Models;
using Tourism.DataAccess.Concrete.EntityFramework;
using Tourism.Entities.Models;

namespace Tourism.DataAccess.Concrete.Models
{
    public class EfOperationMainDal : EfEntityRepositoryBase<OperationMain, AppDbContext>, IOperationMainDal
    {

    }
}

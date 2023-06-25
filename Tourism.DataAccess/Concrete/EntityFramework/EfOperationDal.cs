using Tourism.Core.DataAccess.EntityFramework.Concrete;
using Tourism.DataAccess.Abstract;
using Tourism.Entities.Concrete;

namespace Tourism.DataAccess.Concrete.EntityFramework
{
    public class EfOperationDal : EfEntityRepositoryBase<Operation, AppDbContext>, IOperationDal
    {

    }
}

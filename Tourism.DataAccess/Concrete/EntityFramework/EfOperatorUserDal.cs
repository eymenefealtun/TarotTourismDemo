using Tourism.DataAccess.Concrete.EntityFramework;

namespace Tourism.Entities.Concrete
{
    public class EfOperatorUserDal : EfEntityRepositoryBase<OperatorUser, AppDbContext>, IOperatorUserDal
    {
    }
}

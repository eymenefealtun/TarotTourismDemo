using Tourism.Core.DataAccess.EntityFramework.Abstract;
using Tourism.Entities.Concrete;

namespace Tourism.DataAccess.Abstract
{

    public interface IRoleDal : IEntityRepository<Role>
    {
        //OperatorUser GetByUsernameAndPassword(string username, string password);
        //OperatorUser GetByUsernameSqlRaw(string username);

    }
}

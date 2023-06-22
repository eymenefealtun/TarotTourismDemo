using Tourism.Entities.Models;

namespace Tourism.DataAccess.Abstract.Models
{
    public interface IOperatorUserFullDal : IEntityRepository<OperatorUserFull>
    {
        List<OperatorUserFull> GetOperatorUsers();
    }
}

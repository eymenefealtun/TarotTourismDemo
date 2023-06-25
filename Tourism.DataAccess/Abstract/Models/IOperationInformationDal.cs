using Tourism.Core.DataAccess.EntityFramework.Abstract;
using Tourism.Entities.Models;

namespace Tourism.DataAccess.Abstract.Models
{
    public interface IOperationInformationDal : IEntityRepository<OperationInformation>
    {
        OperationInformation GetOperationInformation(int operationId);

    }
}

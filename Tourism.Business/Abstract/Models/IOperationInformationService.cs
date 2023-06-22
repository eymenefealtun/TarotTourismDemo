using Tourism.Entities.Models;

namespace Tourism.Business.Abstract.Models
{
    public interface IOperationInformationService
    {
        OperationInformation GetOperationInformation(int operationId);                     

    }
}

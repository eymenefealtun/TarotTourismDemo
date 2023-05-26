using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Entities.Models;

namespace Tourism.Business.Abstract.Models
{
    public interface IOperationInformationService
    {
        OperationInformation GetOperationInformation(int operationId);                     

    }
}

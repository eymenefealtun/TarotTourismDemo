using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Business.Abstract.Models;
using Tourism.DataAccess.Abstract.Models;
using Tourism.Entities.Models;

namespace Tourism.Business.Concrete.Models
{
    public class OperationInformationManager : IOperationInformationService
    {
        private IOperationInformationDal _operationInformationDal;
        public OperationInformationManager(IOperationInformationDal operationInformationDal)
        {
            _operationInformationDal = operationInformationDal;
        }

        public OperationInformation GetOperationInformation(int operationId)
        {
            return _operationInformationDal.GetOperationInformation(operationId);
        }


    }
}

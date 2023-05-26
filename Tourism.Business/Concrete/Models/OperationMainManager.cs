using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Business.Abstract.Models;
using Tourism.DataAccess.Abstract.Models;
using Tourism.DataAccess.Concrete.EntityFramework;
using Tourism.Entities.Abstract;
using Tourism.Entities.Concrete;
using Tourism.Entities.Models;

namespace Tourism.Business.Concrete.Models
{
    public class OperationMainManager : IOperationMainService
    {
        private IOperationMainDal _operationMainDal;
        public OperationMainManager(IOperationMainDal operationMainDal)
        {
            _operationMainDal = operationMainDal;
        }
                
        public List<OperationMain> GetOperationMains()
        {
            return _operationMainDal.GetOperationMain();
        }

        public List<OperationMain> SearchOperationMain(string documentCode, int mainCategoryId, int subCategoryId, DateTime startDate, DateTime endDate, int operatorId)
        {       
            return _operationMainDal.SearchOperationMain(documentCode, mainCategoryId, subCategoryId, startDate, endDate, operatorId);
        }












    }
}

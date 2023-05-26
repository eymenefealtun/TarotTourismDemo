using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Entities.Models;

namespace Tourism.Business.Abstract.Models
{
    public interface IOperationMainService
    {
        List<OperationMain> GetOperationMains();        
        List<OperationMain> SearchOperationMain(string documentCode, int mainCategoryId, int subCategoryId, DateTime startDate, DateTime endDate,int operatorId);
    }
}

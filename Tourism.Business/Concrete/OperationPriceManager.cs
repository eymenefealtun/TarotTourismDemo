using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.DataAccess.Concrete.EntityFramework;


namespace Tourism.Entities.Concrete
{
    public class OperationPriceManager : IOperationPriceService
    {
        private IOperationPriceDal _operationPriceDal;
        public OperationPriceManager(IOperationPriceDal operationPriceDal)
        {
            _operationPriceDal = operationPriceDal;         
        }



    }
}

using Tourism.Entities.Abstract;

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

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

        public OperationPrice GetByOperation(int operationId)
        {
            return _operationPriceDal.Get(x => x.OperationId == operationId);           
        }


    }
}

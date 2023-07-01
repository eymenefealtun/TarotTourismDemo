using Tourism.Business.Abstract.Models;
using Tourism.DataAccess.Abstract.Models;
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

        public List<OperationMain> GetByDocumentCode(string documentCode)
        {
            return _operationMainDal.GetByDocumentCode(documentCode);

        }



        //public OperationMain GetByOperationId(int operationId)

        //{
        //    return _operationMainDal.Get(x => x.Id == operationId);
        //}

        public List<OperationMain> GetOperationMain()
        {
            return _operationMainDal.GetOperationMain();
        }

        //public List<OperationMain> GetOperationMainByOperationId(int operationId)
        //{
        //    return _operationMainDal.GetAll(x=>x.Id == operationId);
        //}

        public List<OperationMain> SearchOperationMain(string documentCode, int mainCategoryId, int subCategoryId, DateTime startDate, DateTime endDate, int operatorId, int currencyId, bool isActive)
        {
            return _operationMainDal.SearchOperationMain(documentCode, mainCategoryId, subCategoryId, startDate, endDate, operatorId, currencyId, isActive);
        }












    }
}

using Tourism.Business.Abstract.Models;
using Tourism.DataAccess.Abstract.Models;
using Tourism.Entities.Models;

namespace Tourism.Business.Concrete.Models
{
    public class OperatorUserFullManager : IOperatorUserFullService
    {
        private IOperatorUserFullDal _operationFullDal;
        public OperatorUserFullManager(IOperatorUserFullDal operationFullDal)
        {
            _operationFullDal = operationFullDal;
        }

        public List<OperatorUserFull> GetOperatorUsers()
        {
            return _operationFullDal.GetOperatorUsers();
        }


    }
}

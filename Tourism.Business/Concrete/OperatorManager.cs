using System.ComponentModel;
using Tourism.Entities.Abstract;


namespace Tourism.Entities.Concrete
{
    public class OperatorManager : IOperatorService
    {
        private IOperatorDal _operatorDal;
        public OperatorManager(IOperatorDal operatorDal)
        {
            _operatorDal = operatorDal;
        }
        public List<Operator> GetAll()
        {
            return _operatorDal.GetAll();
        }

        public List<Operator> GetByName(string operatorName)
        {
            return _operatorDal.GetAll(x => x.Name.Contains(operatorName));
        }

        public Operator GetByOperatorId(int operatorId)
        {
            return _operatorDal.Get(x => x.Id == operatorId);
        }
    }
}

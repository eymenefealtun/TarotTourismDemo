using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.DataAccess.Abstract;
using Tourism.DataAccess.Concrete.EntityFramework;

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

        public Operator GetByOperatorId(int operatorId)             
        {
            return _operatorDal.Get(x=>x.Id == operatorId);          
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Business.Utilites;
using Tourism.Business.ValidationRules.FluentValidation;
using Tourism.DataAccess.Abstract;
using Tourism.Entities.Concrete;
using Tourism.Entities.Models;

namespace Tourism.DataAccess.Concrete.EntityFramework
{
    public class OperationManager : IOperationService
    {
        private IOperationDal _operationDal;
        public OperationManager(IOperationDal operationDal)
        {
            _operationDal = operationDal;
        }

        public List<Operation> GetAllWithFilter()
        {
            return _operationDal.GetAllWithFilter();
        }
        public List<Operation> GetAll()
        {
            return _operationDal.GetAll();
        }

        public Operation Add(Operation operation)
        {
            ValidationTool.FluentValidate(new OperationValidator(), operation);
            return _operationDal.Add(operation);
        }



        public Operation Update(Operation operation)
        {
           ValidationTool.FluentValidate(new OperationValidator(), operation);
            return _operationDal.Update(operation);
        }
    }
}

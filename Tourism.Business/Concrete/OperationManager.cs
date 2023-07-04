using Azure;
using System.Security.Cryptography.X509Certificates;
using Tourism.Business.ValidationRules.FluentValidation;
using Tourism.Core.CrossCuttingConcerns.Validation.ValidatorTool;
using Tourism.DataAccess.Abstract;
using Tourism.Entities.Concrete;
using Operation = Tourism.Entities.Concrete.Operation;

namespace Tourism.DataAccess.Concrete.EntityFramework
{
    public class OperationManager : IOperationService
    {
        private IOperationDal _operationDal;
        public OperationManager(IOperationDal operationDal)
        {
            _operationDal = operationDal;
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


        public Operation GetByOperationId(int operationId)
        {
            return _operationDal.Get(x => x.Id == operationId);
        }

        public List<Operation> GetByDocumentCode(string documentCode)
        {
            return _operationDal.GetAll(x => x.DocumentCode.Contains(documentCode));
        }
        public List<Operation> GetBySubCategoryAndDocumentCode(string documentCode, int subCategoryId)
        {
            return _operationDal.GetAll(x => x.SubCategoryId == subCategoryId && x.DocumentCode.Contains(documentCode));
        }

        public List<Operation> GetBySubCategory(int subCategoryId)
        {
            return _operationDal.GetAll(x => x.SubCategoryId == subCategoryId);
        }

        public List<Operation> BulkInsert(List<Operation> opearationList)
        {
            ValidationTool.FluentValidateForList(new OperationValidator(), opearationList.ToArray());
            return _operationDal.BulkInsert(opearationList);            
        }
    }
}

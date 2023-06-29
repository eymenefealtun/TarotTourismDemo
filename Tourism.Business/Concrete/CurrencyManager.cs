using Tourism.Business.ValidationRules.FluentValidation;
using Tourism.Core.CrossCuttingConcerns.Validation.ValidatorTool;
using Tourism.Entities.Abstract;

namespace Tourism.Entities.Concrete
{
    public class CurrencyManager : ICurrencyService
    {
        private ICurrencyDal _currencyDal;
        public CurrencyManager(ICurrencyDal currencyDal)
        {
            _currencyDal = currencyDal; 
        }

        public Currency Add(Currency currency)
        {
            ValidationTool.FluentValidate(new CurrencyValidator(), currency);
            return _currencyDal.Add(currency);
        }

        public List<Currency> GetAll()
        {       
            return _currencyDal.GetAll();
        }

        public List<Currency> GetByName(string currencyName)
        {
            return _currencyDal.GetAll(x=>x.Name.Contains(currencyName));
        }

        public List<Currency> GetByOperation(int operationId)
        {
            return _currencyDal.GetByOperation(operationId);           
        }

        public Currency Update(Currency currency)       
        {
            ValidationTool.FluentValidate(new CurrencyValidator(), currency);
            return _currencyDal.Update(currency);                   
        }
    }
}       

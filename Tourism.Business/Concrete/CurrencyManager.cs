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

        public Currency Update(Currency currency)       
        {
            ValidationTool.FluentValidate(new CurrencyValidator(), currency);
            return _currencyDal.Update(currency);                   
        }
    }
}       

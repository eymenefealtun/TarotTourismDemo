using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.DataAccess.Concrete.EntityFramework;

namespace Tourism.Entities.Concrete
{
    public class CurrencyManager : ICurrencyService
    {
        private ICurrencyDal _currencyDal;
        public CurrencyManager(ICurrencyDal currencyDal)
        {
            _currencyDal = currencyDal; 
        }

        public List<Currency> GetAll()
        {       
            return _currencyDal.GetAll();
        }

    }
}       

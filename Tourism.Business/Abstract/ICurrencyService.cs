namespace Tourism.Entities.Concrete
{
    public interface ICurrencyService 
    {
        List<Currency> GetAll();
        List<Currency> GetByOperation(int operationId);
        List<Currency> GetByName(string currencyName);

        Currency Update(Currency currency);
        Currency Add(Currency currency);        


    }
}

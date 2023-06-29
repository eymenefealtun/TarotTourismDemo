
namespace Tourism.Entities.Concrete
{
    public interface IOperatorService
    {
        List<Operator> GetAll();
        List<Operator> GetByName(string operatorName);
        Operator GetByOperatorId(int operatorId);
    }               
}

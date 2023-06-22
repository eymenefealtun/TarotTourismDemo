
namespace Tourism.Entities.Concrete
{
    public interface IOperatorUserService
    {
        OperatorUser GetByUserId(int userId);
        List<OperatorUser> GetAll();
        OperatorUser Add(OperatorUser operatorUser);
        OperatorUser Update(OperatorUser operatorUser);

    }
}

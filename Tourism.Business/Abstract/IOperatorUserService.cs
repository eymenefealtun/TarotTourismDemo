
namespace Tourism.Entities.Concrete
{
    public interface IOperatorUserService
    {
        //Task<OperatorUser> GetByUserId(int userId);
        OperatorUser GetByUserId(int userId);
        OperatorUser GetByUsernameAndPassword(string username, string password);
        OperatorUser GetByUsername(string username);
        OperatorUser GetByPassword(string username);
        List<OperatorUser> GetAll();
        OperatorUser Add(OperatorUser operatorUser);
        OperatorUser Update(OperatorUser operatorUser);
        OperatorUser GetByUsernameSqlRaw(string username);

    }
}

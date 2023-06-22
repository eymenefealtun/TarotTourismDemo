
namespace Tourism.Entities.Concrete
{
    public interface IUserLevelService
    {
        List<UserLevel> GetAll();       
        UserLevel Add(UserLevel userLevel);
    }
}

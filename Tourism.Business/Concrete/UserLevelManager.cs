using Tourism.Entities.Abstract;

namespace Tourism.Entities.Concrete
{
    public class UserLevelManager : IUserLevelService
    {
        private IUserLevelDal _userLevelDal;
        public UserLevelManager(IUserLevelDal userLevelDal)         
        {
            _userLevelDal = userLevelDal;           
        }

        public List<UserLevel> GetAll()
        {
            return _userLevelDal.GetAll();
        }

        public UserLevel Add(UserLevel userLevel)
        {
            return _userLevelDal.Add(userLevel);     
        }
    }
}

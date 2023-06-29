using Tourism.Entities.Abstract;


namespace Tourism.Entities.Concrete
{
    public class AgencyUserManager : IAgencyUserService
    {
        private IAgencyUserDal _agencyUserDal;
        public AgencyUserManager(IAgencyUserDal agencyUserDal)
        {
            _agencyUserDal = agencyUserDal;
        }

        public AgencyUser Get(int userId)
        {
            return _agencyUserDal.Get(x => x.Id == userId);
        }
        public List<AgencyUser> GetAll()
        {
            return _agencyUserDal.GetAll();
        }

        public List<AgencyUser> GetByName(string agencyUserName)
        {
            return _agencyUserDal.GetAll(x=>x.Username.Contains(agencyUserName));
        }
    }

}

using Tourism.Entities.Abstract;

namespace Tourism.Entities.Concrete
{
    public class AgencyManager : IAgencyService
    {
        private IAgencyDal _agencyDal;
        public AgencyManager(IAgencyDal agencyService)
        {
            _agencyDal = agencyService;
        }

        public List<Agency> GetAll()
        {
            return _agencyDal.GetAll();
        }

        public Agency GetByAgencyId(int agencyId)
        {
            return _agencyDal.Get(x => x.Id == agencyId);
        }

        public List<Agency> GetByName(string agencyName)
        {
            return _agencyDal.GetAll(x => x.Name.Contains(agencyName));
        }
    }
}

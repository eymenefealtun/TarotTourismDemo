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

        public Agency GetByAgencyId(int agencyId)
        {
            return _agencyDal.Get(x => x.Id == agencyId);
        }
    }
}

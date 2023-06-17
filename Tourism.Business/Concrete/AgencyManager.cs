using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.DataAccess.Concrete.EntityFramework;

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

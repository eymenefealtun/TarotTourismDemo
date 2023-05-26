using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.DataAccess.Concrete.EntityFramework;

namespace Tourism.Entities.Concrete
{
    public class BedTypeManager : IBedTypeService
    {
        private IBedTypeDal _bedTypeDal;
        public BedTypeManager(IBedTypeDal bedTypedal )
        {
            _bedTypeDal = bedTypedal;       
        }

                


    }
}

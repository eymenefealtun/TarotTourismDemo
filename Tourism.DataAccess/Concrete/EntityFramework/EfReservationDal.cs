using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.DataAccess.Concrete.EntityFramework;
using Tourism.Entities.Abstract;

namespace Tourism.Entities.Concrete
{
    public class EfReservationDal : EfEntityRepositoryBase<Reservation, AppDbContext>, IReservationDal
    {       
    }
}

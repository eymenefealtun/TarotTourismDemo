using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.DataAccess.Abstract.Models;
using Tourism.DataAccess.Concrete.EntityFramework;
using Tourism.Entities.Models;

namespace Tourism.DataAccess.Concrete.Models
{
    public class EfDailySaleDal : EfEntityRepositoryBase<DailySale, AppDbContext>, IDailySaleDal
    {

    }
}

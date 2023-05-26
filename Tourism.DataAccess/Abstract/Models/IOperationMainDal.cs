using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Entities.Concrete;
using Tourism.Entities.Models;

namespace Tourism.DataAccess.Abstract.Models
{
    public interface IOperationMainDal : IEntityRepository<OperationMain>
    {
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Entities.Concrete;

namespace Tourism.DataAccess.Abstract
{
    public interface IOperationDal : IEntityRepository<Operation>
    {
    }
}

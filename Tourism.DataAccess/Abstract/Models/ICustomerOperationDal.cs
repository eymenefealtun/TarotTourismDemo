using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Tourism.Entities.Models;

namespace Tourism.DataAccess.Abstract.Models
{
    public interface ICustomerOperationDal : IEntityRepository<CustomerOperation>
    {
    }
}
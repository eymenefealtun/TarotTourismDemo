using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.DataAccess.Abstract;

namespace Tourism.Entities.Concrete
{
    public interface IOperatorService
    {
        List<Operator> GetAll();        

    }
}

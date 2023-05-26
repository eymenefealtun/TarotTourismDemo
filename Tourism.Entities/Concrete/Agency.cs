using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Entities.Abstract;

namespace Tourism.Entities.Concrete
{
    public class Agency : IEntity
    {

        public int Id { get; set; }
        public string Name { get; set; }        
        List<AgencyUser> AgencyUsers { get; set; } 

    }
}

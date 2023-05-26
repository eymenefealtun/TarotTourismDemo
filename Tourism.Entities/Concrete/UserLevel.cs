using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Entities.Abstract;

namespace Tourism.Entities.Concrete
{
    public class UserLevel : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
        public List<OperatorUser> OperatorUsers { get; set; }   

    }
}

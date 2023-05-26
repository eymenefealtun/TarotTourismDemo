using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Entities.Abstract;

namespace Tourism.Entities.Concrete
{
    public class AgencyUser : IEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int AgencyId { get; set; }   
        public List<Reservation> Reservations { get; set; }     
        public Agency Agency { get; set; }        
    }

}

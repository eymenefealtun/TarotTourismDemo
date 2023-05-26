using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Entities.Abstract;

namespace Tourism.Entities.Models
{
    [Keyless]
    public class CustomerOperation :IEntity
    {
        public string FirstName { get; set; }
        public string LastName{ get; set; } 
        public string Phone { get; set; }
        public DateTime BirthDate{ get; set; }
        public string Gender { get; set; }
        public string IdNumber { get; set; }        
        public int RoomId { get; set; }
        public int ReservationId { get; set; }
        public string BedType { get; set; } 
        public string ReservationCode { get; set; }         
    }
}

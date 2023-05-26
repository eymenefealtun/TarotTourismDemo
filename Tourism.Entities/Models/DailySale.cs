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
    public class DailySale : IEntity        
    {
        public string ReservationCode { get; set; }
        public int Pax { get; set; }
        public int Room { get; set; }
        [Precision(18,2)]
        public decimal TotalPrice { get; set; }
        public DateTime CreatedDate { get; set; }                   
        public string DocumentCode { get; set; }        
    }
}

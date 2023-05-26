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
    public class OperationMain : IEntity
    {   
        public string? DocumentCode { get; set; }
        public string Operator { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? Pax { get; set; }       
        public int? Room { get; set; }
        public string Currency { get; set; }
        public int Id { get; set; } 
    }
}

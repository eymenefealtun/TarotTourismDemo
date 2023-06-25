using Microsoft.EntityFrameworkCore;
using Tourism.Core.Entities;

namespace Tourism.Entities.Models
{
    [Keyless]   
    public class DailySale : IEntity        
    {
        public string Operator { get; set; }
        public string Agency { get; set; }
        public string Period { get; set; }
        public string Currency { get; set; }
        public string PurchasedBy { get; set; }     
        public string ReservationCode { get; set; }
        public int Pax { get; set; }
        public int Room { get; set; }
        [Precision(18,2)]
        public decimal TotalPrice { get; set; }
        public DateTime CreatedDate { get; set; }                   
        public string DocumentCode { get; set; }        
    }
}

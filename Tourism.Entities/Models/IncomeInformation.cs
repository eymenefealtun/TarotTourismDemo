using Microsoft.EntityFrameworkCore;
using Tourism.Core.Entities;

namespace Tourism.Entities.Models
{
    [Keyless]
    public class IncomeInformation : IEntity
    {
        [Precision(18,2)]
        public decimal? TotalIncome { get; set; }
        //public decimal TotalIncomeByOperation { get; set; }
        //public decimal TotalIncomeByReservation { get; set; }
        //public decimal TotalIncomeByAgencyUser { get; set; }        
        //public decimal TotalIncomeByAgency { get; set; }                
    }
}

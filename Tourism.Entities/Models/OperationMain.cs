using Microsoft.EntityFrameworkCore;
using Tourism.Core.Entities;

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
        public int SubCategoryId { get; set; }
        [Precision(18, 2)]
        public decimal? CurrentIncome { get; set; }
    }
}

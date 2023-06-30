using Microsoft.EntityFrameworkCore;
using Tourism.Core.Entities;

namespace Tourism.Entities.Models
{
    [Keyless]
    public class IncomeInformation : IEntity
    {
        public string? Name { get; set; }
        [Precision(18, 2)]
        public decimal? TotalIncome { get; set; }
    }
}

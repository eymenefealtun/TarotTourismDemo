using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Tourism.Entities.Abstract;

namespace Tourism.Entities.Models
{
    [Keyless]
    public class OperationInformation : IEntity
    {
        public int OperationId { get; set; }
        public string DocumentCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Description { get; set; }
        public string? Note { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string CreatedBy { get; set; }
        public string LastUpdatedBy { get; set; }
        public int CurrencyId { get; set; }
        public int UpdateUserId { get; set; }
        public int CreateUserId { get; set; }
        public int MainCategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public bool IsActive { get; set; }
        public decimal SingleRoom { get; set; }
        public decimal DoubleRoom { get; set; }
        public decimal TripleRoom { get; set; }
        public decimal QuadRoom { get; set; }
        public decimal Child { get; set; }      
        public decimal Baby { get; set; }
        public string CreatedByOperator { get; set; }

        public byte[] OperationRowVersion { get; set; }
        public byte[] OperationPriceRowVersion { get; set; }        


    }
}

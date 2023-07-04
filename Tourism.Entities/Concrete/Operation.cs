using System.ComponentModel.DataAnnotations;
using Tourism.Core.Entities;

namespace Tourism.Entities.Concrete
{
    public class Operation : IEntity
    {
        public int Id { get; set; }
        public string DocumentCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Description { get; set; }
        public string? Note { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int CreatedBy { get; set; }
        public int LastUpdatedBy { get; set; }
        public int CurrencyId { get; set; }
        public int SubCategoryId { get; set; }
        public bool IsActive { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public SubCategory SubCategory { get; set; }
        public Currency Currency { get; set; }
        public OperationPrice OperationPrice { get; set; } = new OperationPrice();   //Opearation üzerinden bu navigation properyty'yi kullanarak product eklemeye çalıştığımız zaman null exception hatası almamak için newledim,//(one-to-many-default) //List yerine ICollection'da kullanılabilir
        public OperatorUser OperatorUserCreated { get; set; }
        public OperatorUser OperatorUserUpdated { get; set; }
        public List<Reservation> Reservations { get; set; }

    }
}

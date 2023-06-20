using System.ComponentModel.DataAnnotations;
using Tourism.Entities.Abstract;

namespace Tourism.Entities.Concrete
{
    public class Reservation : IEntity
    {
        public int Id { get; set; }
        public string ReservationCode { get; set; }
        public int Pax { get; set; }
        public int Room { get; set; }
        public decimal TotalPrice { get; set; }
        public string? Note { get; set; }
        public decimal DiscountedPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public int AgencyUserId { get; set; }
        public int OperationId { get; set; }
        public bool IsActive { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public Operation Operation { get; set; }
        public List<Room> Rooms { get; set; }
        public AgencyUser AgencyUser { get; set; }
    }

}

using Tourism.Core.Entities;

namespace Tourism.Entities.Concrete
{
    public class Room : IEntity
    {

        public int Id { get; set; }
        public int BedTypeId { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        public List<Customer> Customers { get; set; }
        public BedType BedType { get; set; }
    }
}

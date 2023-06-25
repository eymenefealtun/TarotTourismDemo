using System.ComponentModel.DataAnnotations;
using Tourism.Core.Entities;

namespace Tourism.Entities.Models
{

    public class CustomerOperation : IEntity
    {
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string IdNumber { get; set; }
        public int RoomId { get; set; }
        public int ReservationId { get; set; }
        public string? BedType { get; set; }
        public int BedTypeId { get; set; }
        public string ReservationCode { get; set; }
        public string Agency { get; set; }
        public byte[] CustomerRowVersion { get; set; }      
        public bool IsActive { get; set; }
    }
}

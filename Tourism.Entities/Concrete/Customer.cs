using System.ComponentModel.DataAnnotations;
using Tourism.Core.Entities;

namespace Tourism.Entities.Concrete
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string IdNumber { get; set; }
        public int RoomId { get; set; }
        [Timestamp]     
        public byte[] RowVersion { get; set; }
        public Room Room { get; set; }
    }
}

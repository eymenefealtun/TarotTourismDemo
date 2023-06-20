using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Entities.Abstract;

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

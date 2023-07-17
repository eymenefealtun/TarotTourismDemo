using Microsoft.EntityFrameworkCore;
using Tourism.Core.Entities;

namespace Tourism.Entities.Models
{
    [Keyless]
    public class OperatorUserFull : IEntity
    {
        public int OperatorUserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string OperatorName { get; set; }
       // public string Level { get; set; }


        public bool IsActive { get; set; }
        public DateTime DateJoined { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

    }


}

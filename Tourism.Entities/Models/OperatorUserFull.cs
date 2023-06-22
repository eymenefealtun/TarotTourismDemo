using Microsoft.EntityFrameworkCore;
using Tourism.Entities.Abstract;

namespace Tourism.Entities.Models
{
    [Keyless]
    public class OperatorUserFull :IEntity
    {
        public int OperatorUserId { get; set; }     
        public string Username { get; set; }
        public string Password { get; set; }
        public string OperatorName { get; set; }
        public string Level { get; set; }       
    }
}

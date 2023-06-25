using Tourism.Core.Entities;

namespace Tourism.Entities.Concrete
{
    public class AgencyUser : IEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int AgencyId { get; set; }   
        public List<Reservation> Reservations { get; set; }     
        public Agency Agency { get; set; }        
    }

}

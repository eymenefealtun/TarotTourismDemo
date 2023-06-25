using Tourism.Core.Entities;

namespace Tourism.Entities.Concrete
{
    public class Agency : IEntity
    {

        public int Id { get; set; }
        public string Name { get; set; }
        List<AgencyUser> AgencyUsers { get; set; }

    }
}

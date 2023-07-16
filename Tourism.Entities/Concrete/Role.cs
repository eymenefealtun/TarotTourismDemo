using Tourism.Core.Entities;

namespace Tourism.Entities.Concrete
{
    public class Role : IEntity             
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public OperatorUserRole OperatorUserRoles { get; set; }
    }
}

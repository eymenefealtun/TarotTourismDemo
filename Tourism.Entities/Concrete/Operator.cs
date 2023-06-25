using Tourism.Core.Entities;

namespace Tourism.Entities.Concrete
{
    public class Operator : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<OperatorUser> OperatorUsers { get; set; }       

    }
}

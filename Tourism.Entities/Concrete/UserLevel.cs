using Tourism.Entities.Abstract;

namespace Tourism.Entities.Concrete
{
    public class UserLevel : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<OperatorUser> OperatorUsers { get; set; }

    }
}

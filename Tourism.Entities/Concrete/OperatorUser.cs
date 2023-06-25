using Tourism.Core.Entities;

namespace Tourism.Entities.Concrete
{
    public class OperatorUser : IEntity
    {

        public int Id { get; set; }         
        public string Username { get; set; }
        public string Password { get; set; }
        public int OperatorId { get; set; }
        public int UserLevelId { get; set; }
        public List<Operation> OperatorCreate { get; set; }
        public List<Operation> OperatorUpdate { get; set; }
        public UserLevel UserLevel { get; set; }
        public Operator Operator { get; set; }
    }

}

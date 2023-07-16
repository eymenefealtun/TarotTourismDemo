using Tourism.Core.Entities;

namespace Tourism.Entities.Concrete
{
    public class OperatorUserRole : IEntity
    {
        public int Id { get; set; }
        public int OperatorUserId { get; set; }             
        public int RoleId { get; set; }                         

        public OperatorUser OperatorUser { get; set; }              
    }
}

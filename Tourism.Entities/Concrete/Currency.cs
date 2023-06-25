using System.ComponentModel.DataAnnotations;
using Tourism.Core.Entities;

namespace Tourism.Entities.Concrete
{
    public class Currency : IEntity
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Operation> Operations { get; set; }
    }
}

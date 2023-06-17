using System.ComponentModel.DataAnnotations;
using Tourism.Entities.Abstract;

namespace Tourism.Entities.Concrete
{
    public class Currency : IEntity
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Operation> Operations { get; set; }
    }
}

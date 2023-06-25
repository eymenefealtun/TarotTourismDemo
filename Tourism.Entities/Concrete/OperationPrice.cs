using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tourism.Core.Entities;

namespace Tourism.Entities.Concrete
{
    public class OperationPrice : IEntity
    {
        [Key, ForeignKey("Operation")]
        //[Key]
        public int OperationId { get; set; }
        public decimal SingleRoom { get; set; }
        public decimal DoubleRoom { get; set; }
        public decimal TripleRoom { get; set; }
        public decimal QuadRoom { get; set; }
        public decimal Child { get; set; }
        public decimal Baby { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public Operation Operation { get; set; }


    }
}

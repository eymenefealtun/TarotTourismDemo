using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Entities.Abstract;

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

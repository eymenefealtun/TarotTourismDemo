using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Tourism.Entities.Abstract;

namespace Tourism.Entities.Concrete
{
    public class Operation : IEntity
    {
        public int Id { get; set; }
        public string DocumentCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }   
        public string? Description { get; set; }
        public string? Note { get; set; }       
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int CreatedBy { get; set; }
        public int LastUpdatedBy { get; set; }  
        public int CurrencyId { get; set; }
        public int SubCategoryId { get; set; }
        public bool IsActive { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public SubCategory SubCategory { get; set; }         
        public Currency Currency { get; set; }         
        public OperationPrice OperationPrice { get; set; }
        public OperatorUser OperatorUserCreated { get; set; }               
        public OperatorUser OperatorUserUpdated{ get; set; }         
        public List<Reservation> Reservations { get; set; } 

    }
}

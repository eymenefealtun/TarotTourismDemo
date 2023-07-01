using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Tourism.Core.Entities;

namespace Tourism.Entities.Concrete
{
    public class Preference :IEntity
    {
        [Key, ForeignKey("OperatorUser")]
        public int OperatorUserId { get; set; }
        public int BackgroundThemeId { get; set; }

    }
}

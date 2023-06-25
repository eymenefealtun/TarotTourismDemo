using Tourism.Core.Entities;

namespace Tourism.Entities.Concrete
{
    public class BedType : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Room> Rooms { get; set; }
    }
}

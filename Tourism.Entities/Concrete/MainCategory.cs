using Tourism.Core.Entities;

namespace Tourism.Entities.Concrete
{
    public class MainCategory : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SubCategory> SubCategories { get; set; }


    }
}

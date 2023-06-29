
namespace Tourism.Entities.Concrete
{
    public interface IBedTypeService
    {
        List<BedType> GetAll();
        List<BedType> GetByName(string bedTypeName);
    }
}

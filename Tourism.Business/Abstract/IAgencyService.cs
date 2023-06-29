
namespace Tourism.Entities.Concrete
{
    public interface IAgencyService
    {
        Agency GetByAgencyId(int agencyId);
        List<Agency> GetAll();
        List<Agency> GetByName(string agencyName);

    }

}

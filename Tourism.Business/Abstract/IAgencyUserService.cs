
namespace Tourism.Entities.Concrete
{
    public interface IAgencyUserService
    {
        AgencyUser Get(int userId);
        List<AgencyUser> GetAll();
        List<AgencyUser> GetByName(string agencyUserName);
    }

}

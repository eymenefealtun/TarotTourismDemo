using Tourism.Entities.Concrete;

namespace Tourism.Business.Abstract
{
    public interface IRoleService
    {
        Role GetByRoleName(string roleName);            
    }
}

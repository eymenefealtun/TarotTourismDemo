using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.DataAccess.Abstract;

namespace Tourism.Entities.Concrete
{
    public interface ISubCategoryService
    {
        List<SubCategory> GetAll();
        List<SubCategory> GetByMainCategory(int mainCategoryId);
        SubCategory GetBySubCategoryId(int subCategoryId);      
    }
}

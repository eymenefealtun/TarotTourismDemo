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
        SubCategory Add(SubCategory subCategory);       
        List<SubCategory> GetAll();
        List<SubCategory> GetByMainCategory(int mainCategoryId);
        List<SubCategory> GetByCategoryName(string subCategoryname);
        SubCategory GetBySubCategoryId(int subCategoryId);      
        SubCategory Update(SubCategory subCategory);      
    }
}

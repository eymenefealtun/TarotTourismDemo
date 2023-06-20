using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.DataAccess.Abstract;

namespace Tourism.Entities.Concrete
{
    public interface IMainCategoryService
    {
        List<MainCategory> GetAll();                
        MainCategory GetByMainCategoryId(int mainCategoryId);                           
        MainCategory Add(MainCategory mainCategory);                                  
        MainCategory Update(MainCategory mainCategory);                           
       // MainCategory GetBySubcategoryId(int mainCategoryId);                           
    }       
}
        
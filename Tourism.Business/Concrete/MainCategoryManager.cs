using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.DataAccess.Concrete.EntityFramework;

namespace Tourism.Entities.Concrete
{
    public class MainCategoryManager : IMainCategoryService
    {
        private IMainCategoryDal _mainCategoryDal;  
        public MainCategoryManager(IMainCategoryDal mainCategoryDal)
        {
            _mainCategoryDal = mainCategoryDal;                 
        }

        public MainCategory GetByMainCategoryId(int mainCategoryId)
        {       
            return _mainCategoryDal.Get(x=>x.Id == mainCategoryId);      
        }
        //public MainCategory GetBySubcategoryId(int subCateogryId)
        //{
        //    return _mainCategoryDal.Get(x=>x.Id == subCateogryId);              
        //}

        public List<MainCategory> GetAll()          
        {
            return _mainCategoryDal.GetAll();           
        }

        public MainCategory Update(MainCategory mainCategory)
        {
            return _mainCategoryDal.Update(mainCategory);
        }

        public MainCategory Add(MainCategory mainCategory)
        {           
            return _mainCategoryDal.Add(mainCategory);
        }
    }
}

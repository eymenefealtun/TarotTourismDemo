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
        public List<MainCategory> GetAll()          
        {
            return _mainCategoryDal.GetAll();           
        }




    }
}

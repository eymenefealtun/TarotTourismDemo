using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.DataAccess.Concrete.EntityFramework;

namespace Tourism.Entities.Concrete
{
    public class SubCategoryManager : ISubCategoryService
    {
        private ISubCategoryDal _subCategoryDal;
        public SubCategoryManager(ISubCategoryDal subCategoryDal)
        {
            _subCategoryDal = subCategoryDal;
        }

        public List<SubCategory> GetAll()
        {
            return _subCategoryDal.GetAll();            
        }
        public List<SubCategory> GetByMainCategory(int mainCategoryId)
        {
            return _subCategoryDal.GetAllWithFilter(x => x.MainCategoryId == mainCategoryId);
        }
        public SubCategory GetBySubCategoryId(int subCategoryId)
        {
            return _subCategoryDal.Get(x => x.Id == subCategoryId);
        }

    }
}

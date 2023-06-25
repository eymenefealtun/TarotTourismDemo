using Tourism.Business.ValidationRules.FluentValidation;
using Tourism.Core.CrossCuttingConcerns.Validation.ValidatorTool;
using Tourism.Entities.Abstract;

namespace Tourism.Entities.Concrete
{
    public class SubCategoryManager : ISubCategoryService
    {
        private ISubCategoryDal _subCategoryDal;
        public SubCategoryManager(ISubCategoryDal subCategoryDal)
        {
            _subCategoryDal = subCategoryDal;
        }

        public SubCategory Add(SubCategory subCategory)
        {
            ValidationTool.FluentValidate(new SubCategoryValidator(), subCategory);
            return _subCategoryDal.Add(subCategory);
        }

        public List<SubCategory> GetAll()
        {
            return _subCategoryDal.GetAll();
        }
        public List<SubCategory> GetByMainCategory(int mainCategoryId)
        {
            return _subCategoryDal.GetAll(x => x.MainCategoryId == mainCategoryId);
        }
        public SubCategory GetBySubCategoryId(int subCategoryId)
        {
            return _subCategoryDal.Get(x => x.Id == subCategoryId);
        }

        public SubCategory Update(SubCategory subCategory)
        {
            ValidationTool.FluentValidate(new SubCategoryValidator(), subCategory);
            return _subCategoryDal.Update(subCategory);
        }
    }
}

﻿using Tourism.Business.Utilites;
using Tourism.Business.ValidationRules.FluentValidation;

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
            return _mainCategoryDal.Get(x => x.Id == mainCategoryId);
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
            ValidationTool.FluentValidate(new MainCategoryValidator(), mainCategory);
            return _mainCategoryDal.Update(mainCategory);
        }

        public MainCategory Add(MainCategory mainCategory)
        {
            ValidationTool.FluentValidate(new MainCategoryValidator(), mainCategory);
            return _mainCategoryDal.Add(mainCategory);
        }
    }
}


namespace Tourism.Entities.Concrete
{
    public interface IMainCategoryService
    {
        List<MainCategory> GetAll();
        List<MainCategory> GetByCategoryName(string mainCategoryname);
        MainCategory GetByMainCategoryId(int mainCategoryId);
        MainCategory Add(MainCategory mainCategory);
        MainCategory Update(MainCategory mainCategory);
        // MainCategory GetBySubcategoryId(int mainCategoryId);                           
    }
}

using FluentValidation;
using Tourism.Entities.Concrete;

namespace Tourism.Business.ValidationRules.FluentValidation
{
    public class SubCategoryValidator : AbstractValidator<SubCategory>
    {

        public SubCategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().Length(1, 100).WithMessage("Subcategory must be between 1-100 chracter!");

        }


    }
}

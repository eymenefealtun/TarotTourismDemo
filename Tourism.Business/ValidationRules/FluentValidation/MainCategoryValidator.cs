using FluentValidation;
using Tourism.Entities.Concrete;

namespace Tourism.Business.ValidationRules.FluentValidation
{
    public class MainCategoryValidator : AbstractValidator<MainCategory>
    {
        public MainCategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().Length(1, 100).WithMessage("Main category must be between 1-100 chracter!");

        }



    }
}

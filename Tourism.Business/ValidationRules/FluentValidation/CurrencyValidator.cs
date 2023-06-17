using FluentValidation;
using Tourism.Entities.Concrete;

namespace Tourism.Business.ValidationRules.FluentValidation
{
    public class CurrencyValidator : AbstractValidator<Currency>
    {

        public CurrencyValidator()
        {
            RuleFor(x => x.Name).Length(1, 10).WithMessage("Currency must be between 1-10 chracter!");

        }

    }
}

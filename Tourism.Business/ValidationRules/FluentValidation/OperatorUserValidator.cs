using FluentValidation;
using Tourism.Entities.Concrete;

namespace Tourism.Business.ValidationRules.FluentValidation
{
    public class OperatorUserValidator : AbstractValidator<OperatorUser>
    {
        public OperatorUserValidator()
        {

            RuleFor(x => x.Username).NotNull().NotEmpty().MaximumLength(50).WithMessage("Username is not in the correct fomat");
            RuleFor(x => x.Password).NotNull().NotEmpty().MaximumLength(50).WithMessage("Password is not in the correct fomat");

        }




    }
}

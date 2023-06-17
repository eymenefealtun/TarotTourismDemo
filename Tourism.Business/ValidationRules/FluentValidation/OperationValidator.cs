using FluentValidation;
using Tourism.Entities.Concrete;

namespace Tourism.Business.ValidationRules.FluentValidation
{
    public class OperationValidator : AbstractValidator<Operation>
    {
        public OperationValidator()
        {
            RuleFor(x => x.DocumentCode).Length(5, 50);
            RuleFor(x => x.StartDate).LessThan(x => x.EndDate).WithMessage("Start date must be lower than end!");

            RuleFor(x => x.OperationPrice.SingleRoom).GreaterThanOrEqualTo(0);
            RuleFor(x => x.OperationPrice.DoubleRoom).GreaterThanOrEqualTo(0);
            RuleFor(x => x.OperationPrice.TripleRoom).GreaterThanOrEqualTo(0);     
            RuleFor(x => x.OperationPrice.QuadRoom).GreaterThanOrEqualTo(0);
            RuleFor(x => x.OperationPrice.Baby).GreaterThanOrEqualTo(0);
            RuleFor(x => x.OperationPrice.Child).GreaterThanOrEqualTo(0);
        }

    }
}

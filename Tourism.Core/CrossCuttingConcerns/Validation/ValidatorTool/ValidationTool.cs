using FluentValidation;

namespace Tourism.Core.CrossCuttingConcerns.Validation.ValidatorTool
{
    public static class ValidationTool
    {
        public static void FluentValidate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);

            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result.Errors);
            }
        }


    }
}

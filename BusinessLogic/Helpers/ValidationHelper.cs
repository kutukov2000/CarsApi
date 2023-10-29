using BusinessLogic.Exceptions;
using FluentValidation;
using FluentValidation.Results;
using System.Net;
using System.Text;

namespace BusinessLogic.Helpers
{
    public static class ValidationHelper<Model>
    {
        public static void Validate(IValidator<Model> validator, Model model)
        {
            ValidationResult results = validator.Validate(model);

            if (results.IsValid)
            {
                return;
            }

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var failure in results.Errors)
            {
                stringBuilder.Append($"{failure.ErrorMessage} ");
            }

            throw new HttpException(stringBuilder.ToString(), HttpStatusCode.BadRequest);
        }

    }
}

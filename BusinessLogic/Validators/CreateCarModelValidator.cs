using Core.ApiModels;
using FluentValidation;

public class CreateCarModelValidator : AbstractValidator<CreateCarModel>
{
    public CreateCarModelValidator()
    {
        RuleFor(x => x.Producer).NotEmpty().WithMessage("Producer cannot be empty.");
        RuleFor(x => x.Model).NotEmpty().WithMessage("Model cannot be empty.");
        RuleFor(x => x.Year).InclusiveBetween(1900, DateTime.Now.Year).WithMessage("Invalid year.");
        RuleFor(x => x.CategoryId).GreaterThan(0).WithMessage("CategoryId should be greater than 0.");
    }
}


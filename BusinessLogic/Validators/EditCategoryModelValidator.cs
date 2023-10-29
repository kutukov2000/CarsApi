using DataAccess.Data.Entities;
using FluentValidation;

public class EditCategoryModelValidator : AbstractValidator<Category>
{
    public EditCategoryModelValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id should be greater than 0.");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty.");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description cannot be empty.");
    }
}
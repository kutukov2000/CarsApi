using Core.ApiModels;
using FluentValidation;

public class CreateCategoryModelValidator : AbstractValidator<CreateCategoryModel>
{
    public CreateCategoryModelValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty.");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description cannot be empty.");
    }
}
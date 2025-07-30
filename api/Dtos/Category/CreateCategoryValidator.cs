using api.Dtos.Category;
using FluentValidation;

namespace api.Validators
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Category name is required.")
                .MaximumLength(50);
        }
    }
}

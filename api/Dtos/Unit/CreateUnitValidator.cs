using FluentValidation;

namespace api.Dtos.Unit
{
    public class CreateUnitValidator : AbstractValidator<CreateUnitDto>
    {
        public CreateUnitValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Unit name is required.")
                .MaximumLength(50);
        }
    }
}

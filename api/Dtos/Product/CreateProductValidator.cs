using FluentValidation;

namespace api.Dtos.Product
{
    public class CreateProductValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(80);
            RuleFor(x => x.Description).MaximumLength(500);
            RuleFor(x => x.UnitPrice).GreaterThanOrEqualTo(0);
            RuleFor(x => x.StockNow).GreaterThanOrEqualTo(0);
            RuleFor(x => x.ProductCategoryId).GreaterThan(0);
            RuleFor(x => x.ProductUnitId).GreaterThan(0);
            RuleFor(x => x.Supplier).NotEmpty().MaximumLength(80);
            RuleFor(x => x.Color).MaximumLength(30);
        }
    }

    public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(80);
            RuleFor(x => x.Description).MaximumLength(500);
            RuleFor(x => x.UnitPrice).GreaterThanOrEqualTo(0);
            RuleFor(x => x.StockNow).GreaterThanOrEqualTo(0);
            RuleFor(x => x.ProductCategoryId).GreaterThan(0);
            RuleFor(x => x.ProductUnitId).GreaterThan(0);
            RuleFor(x => x.Supplier).NotEmpty().MaximumLength(80);
            RuleFor(x => x.Color).MaximumLength(30);
        }
    }
}

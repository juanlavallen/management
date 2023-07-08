using FluentValidation;

namespace Application.Features.Orders.Commands.AddOrder
{
    public class AddOrderCommandValidator : AbstractValidator<AddOrderCommand>
    {
        public AddOrderCommandValidator()
        {
            RuleFor(x => x.OrderType).NotEmpty()
                .WithMessage("The order type can not be empty")
                .NotNull()
                .MaximumLength(50)
                .WithMessage("the order type can not exceed 50 characters");

            RuleFor(x => x.ToZip).NotEmpty().WithMessage("the zip can not be empty");
            RuleFor(x => x.TotalPrice).NotEmpty().WithMessage("the price can not be empty");
            RuleFor(x => x.Quantity).NotEmpty().WithMessage("the quantity can not be empty");
            RuleFor(x => x.ToAddress).NotEmpty().WithMessage("the address can not be empty");
            RuleFor(x => x.TotalUnits).NotEmpty().WithMessage("the total units can not be empty");
        }
    }
}
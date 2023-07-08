using FluentValidation;

namespace Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(x => x.Status).NotEmpty().WithMessage("The status can not be null");
        }
    }
}
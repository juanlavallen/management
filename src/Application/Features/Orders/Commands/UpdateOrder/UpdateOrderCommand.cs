using Domain.Enums;
using MediatR;

namespace Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest
    {
        public int Id { get; set; }
        public string? OrderType { get; set; }
        public int TotalPrice { get; set; }
        public OrderStatus Status { get; set; }
    }
}
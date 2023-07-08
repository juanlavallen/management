using MediatR;

namespace Application.Features.Orders.Commands.AddOrder
{
    public record AddOrderCommand : IRequest<int>
    {
        public string? OrderType { get; set; }
        public decimal Quantity { get; set; }
        public int TotalUnits { get; set; }
        public int TotalPrice { get; set; }
        public string? ToCity { get; set; }
        public string? ToAddress { get; set; }
        public string? ToZip { get; set; }
    }
}
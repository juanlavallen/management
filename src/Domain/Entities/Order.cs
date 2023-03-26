using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Order : BaseAuditableEntity
    {
        public string? OrderType { get; set; }
        public int TotalUnits { get; set; }
        public int TotalPrice { get; set; }
        public decimal Quantity { get; set; }
        public string? ToCity { get; set; }
        public string? ToAddress { get; set; }
        public string? ToZip { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.New;
    }
}
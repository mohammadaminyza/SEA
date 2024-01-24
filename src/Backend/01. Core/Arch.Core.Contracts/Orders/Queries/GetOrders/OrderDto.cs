namespace Arch.Core.Contracts.Orders.Queries.GetOrders;

public class OrderDto
{
    public long Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public int Count { get; set; }
    public string? CreatedByUserId { get; set; }
    public DateTime? CreatedDateTime { get; set; }
    public string? ModifiedByUserId { get; set; }
    public DateTime? ModifiedDateTime { get; set; }
    public Guid BusinessId { get; set; }
}
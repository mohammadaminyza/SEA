namespace Arch.Core.Contracts.Orders.Queries.GetOrderById;

public class OrderByIdDto
{
    public long Id { get; set; }
    public Guid UserId { get; set; }
    public string? Street { get; set; }
    public string? Plaque { get; set; }
    public string? CreatedByUserId { get; set; }
    public DateTime? CreatedDateTime { get; set; }
    public string? ModifiedByUserId { get; set; }
    public DateTime? ModifiedDateTime { get; set; }
    public Guid BusinessId { get; set; }

}
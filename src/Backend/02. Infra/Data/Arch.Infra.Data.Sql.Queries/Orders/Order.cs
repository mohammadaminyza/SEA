namespace Arch.Infra.Data.Sql.Queries.Orders;

public partial class Order
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public required string Street { get; set; }
    public required string Plaque { get; set; }

    public string? CreatedByUserId { get; set; }
    public DateTime? CreatedDateTime { get; set; }
    public string? ModifiedByUserId { get; set; }
    public DateTime? ModifiedDateTime { get; set; }
}
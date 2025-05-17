namespace BuberDinner.Contracts.Bills
{
    public record BillsResponse(
        Guid Id,
        Guid GuestId,
        Guid DinnerId,
        Guid HostId,
        PriceResponse Price,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime);

    public record PriceResponse(
        decimal Amount,
        string Currency);
}

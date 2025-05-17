namespace BuberDinner.Contracts.Bills
{
    public record CreateBillRequest(
        Guid GuestId,
        Guid DinnerId,
        Guid HostId,
        CreatePriceRequest Price);

    public record CreatePriceRequest(
        decimal Amount,
        string Currency);
}

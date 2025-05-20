namespace BuberDinner.Contracts.Bills
{
    public record UpdateBillRequest(
        UpdatePriceRequest Price);

    public record UpdatePriceRequest(
        decimal Amount,
        string Currency);
}

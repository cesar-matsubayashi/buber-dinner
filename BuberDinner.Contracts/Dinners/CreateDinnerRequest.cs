namespace BuberDinner.Contracts.Dinners
{
    public record CreateDinnerRequest(
        Guid HostId,
        string Name,
        string Description,
        DateTime StartDateTime,
        DateTime EndDateTime,
        bool IsPublic,
        int MaxGuests,
        CreatePriceRequest Price,
        Guid MenuId,
        string ImageUrl,
        CreateLocationRequest Location);

    public record CreatePriceRequest (
        decimal Amount,
        string Currency);

    public record CreateLocationRequest(
        string Name,
        string Address,
        float Latitude,
        float Longitude);
}

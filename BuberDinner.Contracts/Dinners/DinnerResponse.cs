namespace BuberDinner.Contracts.Dinners
{
    public record DinnerResponse(
        Guid Id,
        string Name,
        string Description,
        DateTime StartDateTime,
        DateTime EndDateTime,
        DateTime? StartedDateTime,
        DateTime? EndedDateTime,
        string Status,
        bool IsPublic,
        int MaxGuests,
        PriceResponse Price,
        Guid HostId,
        Guid MenuId,
        string ImageUrl,
        LocationResponse Location,
        List<ReservationResponse> Reservations,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime);

    public record PriceResponse(
        decimal Amount,
        string Currency);

    public record LocationResponse(
        string Name,
        string Address,
        float Latitude,
        float Longitude);

    public record ReservationResponse(
        Guid Id,
        int GuestCount,
        string Status,
        Guid GuestId,
        Guid BillId,
        DateTime? ArrivalDateTime,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime);
}

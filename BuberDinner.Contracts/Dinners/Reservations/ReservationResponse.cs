namespace BuberDinner.Contracts.Dinners.Reservations
{
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

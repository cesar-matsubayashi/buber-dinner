namespace BuberDinner.Contracts.Dinners.Reservations
{
    public record UpdateReservationRequest(
        int GuestCount,
        Guid BillId,
        string Status,
        DateTime? ArrivalDateTime);
}

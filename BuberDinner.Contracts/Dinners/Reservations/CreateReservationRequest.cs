namespace BuberDinner.Contracts.Dinners.Reservations
{
    public record CreateReservationRequest(
        int GuestCount,
        Guid GuestId,
        Guid BillId);
}

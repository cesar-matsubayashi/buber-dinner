namespace BuberDinner.Contracts.Guests.GuestRating
{
    public record CreateGuestRatingRequest(
        Guid HostId,
        Guid DinnerId,
        float Rating);
}

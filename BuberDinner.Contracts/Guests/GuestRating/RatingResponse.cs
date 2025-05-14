namespace BuberDinner.Contracts.Guests.GuestRating
{
    public record RatingResponse(
        Guid Id,
        Guid HostId,
        Guid DinnerId,
        float Rating,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime);
}

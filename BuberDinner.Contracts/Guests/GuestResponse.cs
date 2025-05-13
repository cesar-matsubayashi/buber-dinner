namespace BuberDinner.Contracts.Guests
{
    public record GuestResponse(
        Guid Id,
        string FirstName,
        string LastName,
        string ProfileImage,
        Guid UserId,
        float? AverageRating,
        List<Guid> UpcomingDinnerIds,
        List<Guid> PastDinnerIds,
        List<Guid> PendingDinnerIds,
        List<Guid> BillIds,
        List<Guid> MenuReviewIds,
        List<GuestRatingResponse> GuestRatings,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime);

    public record GuestRatingResponse(
        Guid Id,
        Guid HostId,
        Guid DinnerId,
        float Rating,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime);
}

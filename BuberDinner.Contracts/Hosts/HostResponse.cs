namespace BuberDinner.Contracts.Hosts
{
    public record HostResponse(
        Guid Id,
        string FirstName,
        string LastName,
        string ProfileImage,
        Guid UserId,
        double? AverageRating,
        List<Guid> MenuIds,
        List<Guid> DinnerIds,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime);
}

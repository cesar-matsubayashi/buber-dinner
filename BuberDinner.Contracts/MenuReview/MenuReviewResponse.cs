namespace BuberDinner.Contracts.MenuReview
{
    public record MenuReviewResponse(
        Guid Id,
        float Rating,
        string Comment,
        Guid HostId,
        Guid MenuId,
        Guid GuestId,
        Guid DinnerId,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime);
}

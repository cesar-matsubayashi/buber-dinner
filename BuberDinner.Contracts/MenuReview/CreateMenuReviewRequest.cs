namespace BuberDinner.Contracts.MenuReview
{
    public record CreateMenuReviewRequest(
        float Rating,
        string Comment,
        Guid GuestId,
        Guid DinnerId);
}

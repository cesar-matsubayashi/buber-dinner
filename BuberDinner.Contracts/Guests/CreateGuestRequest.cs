namespace BuberDinner.Contracts.Guests
{
    public record CreateGuestRequest(
        string FirstName,
        string LastName,
        string ProfileImage,
        Guid UserId);
}

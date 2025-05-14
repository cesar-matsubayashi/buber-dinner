namespace BuberDinner.Contracts.Guests
{
    public record UpdateGuestRequest(
        string FirstName,
        string LastName,
        string ProfileImage);
}

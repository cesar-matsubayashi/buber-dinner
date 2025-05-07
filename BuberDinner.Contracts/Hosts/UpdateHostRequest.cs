namespace BuberDinner.Contracts.Hosts
{
    public record UpdateHostRequest(
        string FirstName,
        string LastName,
        string ProfileImage);
}

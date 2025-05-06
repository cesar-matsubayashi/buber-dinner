namespace BuberDinner.Contracts.Hosts
{
    public record CreateHostRequest(
        string FirstName,
        string LastName, 
        string ProfileImage,
        Guid UserId);
}

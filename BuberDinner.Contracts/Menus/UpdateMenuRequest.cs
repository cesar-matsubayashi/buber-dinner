namespace BuberDinner.Contracts.Menus
{
    public record UpdateMenuRequest(
        string Name,
        string Description,
        List<UpdateMenuSectionRequest> Sections);

    public record UpdateMenuSectionRequest(
        string Name,
        string Description,
        List<UpdateMenuItemRequest> Items);

    public record UpdateMenuItemRequest(
        string Name,
        string Description);
}

using BuberDinner.Domain.Dinner;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Dinners.Commands.CreateDinner
{
    public record CreateDinnerCommand(
        HostId HostId,
        string Name,
        string Description,
        DateTime StartDateTime,
        DateTime EndDateTime,
        bool IsPublic,
        int MaxGuests,
        CreatePriceCommand Price,
        MenuId MenuId,
        string ImageUrl,
        CreateLocationCommand Location) : IRequest<ErrorOr<Dinner>>;

    public record CreatePriceCommand(
        decimal Amount,
        string Currency);

    public record CreateLocationCommand(
        string Name,
        string Address,
        float Latitude,
        float Longitude);
}

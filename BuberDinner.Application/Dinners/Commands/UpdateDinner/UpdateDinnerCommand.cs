using BuberDinner.Domain.Dinner;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Dinners.Commands.UpdateDinner
{
    public record UpdateDinnerCommand(
        DinnerId Id,
        string Name,
        string Description,
        DateTime StartDateTime,
        DateTime EndDateTime,
        DateTime? StartedDateTime,
        DateTime? EndedDateTime,
        DinnerStatus Status,
        bool IsPublic,
        int MaxGuests,
        UpdatePriceCommand Price,
        MenuId MenuId,
        string ImageUrl,
        UpdateLocationCommand Location) : IRequest<ErrorOr<Dinner>>;

    public record UpdatePriceCommand(
        decimal Amount,
        string Currency);

    public record UpdateLocationCommand(
        string Name,
        string Address,
        float Latitude,
        float Longitude);
}

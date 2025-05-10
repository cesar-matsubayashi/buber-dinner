using BuberDinner.Domain.Dinner;
using ErrorOr;
using MediatR;

namespace BuberDinner.Contracts.Dinners
{
    public record UpdateDinnerRequest(
        string Name,
        string Description,
        DateTime StartDateTime,
        DateTime EndDateTime,
        DateTime? StartedDateTime,
        DateTime? EndedDateTime,
        string Status,
        bool IsPublic,
        int MaxGuests,
        UpdatePriceRequest Price,
        Guid MenuId,
        string ImageUrl,
        UpdateLocationRequest Location);

    public record UpdatePriceRequest (
        decimal Amount,
        string Currency);

    public record UpdateLocationRequest(
        string Name,
        string Address,
        float Latitude,
        float Longitude);
}

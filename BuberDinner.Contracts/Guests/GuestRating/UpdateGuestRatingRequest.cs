using BuberDinner.Domain.Guest.ValueObjects;

namespace BuberDinner.Contracts.Guests.GuestRating
{
    public record UpdateGuestRatingRequest(
        float Rating);
}

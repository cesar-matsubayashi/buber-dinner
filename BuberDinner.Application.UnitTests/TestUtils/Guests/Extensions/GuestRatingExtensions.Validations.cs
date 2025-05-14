using BuberDinner.Application.Guests.Commands.CreateGuestRating;
using BuberDinner.Application.Guests.Commands.UpdateGuestRating;
using BuberDinner.Domain.Guest.Entities;
using FluentAssertions;

namespace BuberDinner.Application.UnitTests.TestUtils.Guests.Extensions
{
    public static partial class GuestRatingExtensions
    {
        public static void ValidateCreatedFrom(this GuestRating guestRating, CreateGuestRatingCommand command)
        {
            guestRating.HostId.Should().Be(command.HostId);
            guestRating.DinnerId.Should().Be(command.DinnerId);
            guestRating.Rating.Should().Be(command.Rating);
        }

        public static void ValidateUpdatedFrom(this GuestRating guestRating, UpdateGuestRatingCommand command)
        {
            guestRating.Rating.Should().Be(command.Rating);
        }
    }
}

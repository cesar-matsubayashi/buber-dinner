using BuberDinner.Application.Guests.Commands.CreateGuest;
using BuberDinner.Application.Guests.Commands.UpdateGuest;
using BuberDinner.Domain.Guest;
using FluentAssertions;

namespace BuberDinner.Application.UnitTests.TestUtils.Guests.Extensions
{
    public static partial class GuestExtensions
    {
        public static void ValidateCreatedFrom(this Guest guest, CreateGuestCommand command)
        {
            guest.FirstName.Should().Be(command.FirstName);
            guest.LastName.Should().Be(command.LastName);
            guest.ProfileImage.Should().Be(command.ProfileImage);
            guest.UserId.Should().Be(command.UserId);
        }

        public static void ValidateUpdatedFrom(this Guest guest, UpdateGuestCommand command)
        {
            guest.FirstName.Should().Be(command.FirstName);
            guest.LastName.Should().Be(command.LastName);
            guest.ProfileImage.Should().Be(command.ProfileImage);
        }
    }
}

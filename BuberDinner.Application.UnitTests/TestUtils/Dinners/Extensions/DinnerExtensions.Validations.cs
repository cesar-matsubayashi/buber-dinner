using BuberDinner.Application.Dinners.Commands.CreateDinner;
using BuberDinner.Application.Dinners.Commands.UpdateDinner;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner;
using BuberDinner.Domain.Dinner.Entities;
using FluentAssertions;

namespace BuberDinner.Application.UnitTests.TestUtils.Dinners.Extensions
{
    public static partial class DinnerExtensions
    {
        public static void ValidateCreatedFrom( this Dinner dinner, CreateDinnerCommand command)
        {
            dinner.HostId.Should().Be(command.HostId);
            dinner.Name.Should().Be(command.Name);
            dinner.Description.Should().Be(command.Description);
            dinner.StartDateTime.Should().Be(command.StartDateTime);
            dinner.EndDateTime.Should().Be(command.EndDateTime);
            dinner.IsPublic.Should().Be(command.IsPublic);
            dinner.MaxGuests.Should().Be(command.MaxGuests);
            dinner.MenuId.Should().Be(command.MenuId);
            dinner.ImageUrl.Should().Be(command.ImageUrl);
            ValidatePrice(dinner.Price, command.Price);
            ValidateLocation(dinner.Location, command.Location);
        }

        static void ValidatePrice(Price price, CreatePriceCommand command)
        {
            price.Amount.Should().Be(command.Amount);
            price.Currency.Should().Be(command.Currency);
        }

        static void ValidateLocation(Location location, CreateLocationCommand command)
        {
            location.Name.Should().Be(command.Name);
            location.Address.Should().Be(command.Address);
            location.Latitude.Should().Be(command.Latitude);
            location.Longitude.Should().Be(command.Longitude);
        }

        public static void ValidateUpdatedFrom(this Dinner dinner, UpdateDinnerCommand command)
        {
            dinner.Id.Should().Be(command.Id);
            dinner.Name.Should().Be(command.Name);
            dinner.Description.Should().Be(command.Description);
            dinner.StartDateTime.Should().Be(command.StartDateTime);
            dinner.EndDateTime.Should().Be(command.EndDateTime);
            dinner.StartedDateTime.Should().Be(command.StartedDateTime);
            dinner.EndedDateTime.Should().Be(command.EndedDateTime);
            dinner.Status.Should().Be(command.Status);
            dinner.IsPublic.Should().Be(command.IsPublic);
            dinner.MaxGuests.Should().Be(command.MaxGuests);
            dinner.MenuId.Should().Be(command.MenuId);
            dinner.ImageUrl.Should().Be(command.ImageUrl);
            ValidatePrice(dinner.Price, command.Price);
            ValidateLocation(dinner.Location, command.Location);
        }

        static void ValidatePrice(Price price, UpdatePriceCommand command)
        {
            price.Amount.Should().Be(command.Amount);
            price.Currency.Should().Be(command.Currency);
        }

        static void ValidateLocation(Location location, UpdateLocationCommand command)
        {
            location.Name.Should().Be(command.Name);
            location.Address.Should().Be(command.Address);
            location.Latitude.Should().Be(command.Latitude);
            location.Longitude.Should().Be(command.Longitude);
        }
    }
}

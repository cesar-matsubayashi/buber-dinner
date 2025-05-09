using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner;
using BuberDinner.Domain.Dinner.Entities;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Dinners.Commands.CreateDinner
{
    public class CreateDinnerCommandHandler
        : IRequestHandler<CreateDinnerCommand, ErrorOr<Dinner>>
    {
        private readonly IDinnerRepository _dinnerRepository;

        public CreateDinnerCommandHandler(IDinnerRepository dinnerRepository)
        {
            _dinnerRepository = dinnerRepository;
        }

        public async Task<ErrorOr<Dinner>> Handle(
            CreateDinnerCommand request, 
            CancellationToken cancellationToken)
        {
            var price = Price.Create(
                request.Price.Amount,
                request.Price.Currency);

            var location = Location.Create(
                request.Location.Name,
                request.Location.Address,
                request.Location.Latitude,
                request.Location.Longitude);

            var dinner = Dinner.Create(
                request.Name,
                request.Description,
                request.StartDateTime,
                request.EndDateTime,
                request.IsPublic,
                request.MaxGuests,
                price,
                request.HostId,
                request.MenuId,
                request.ImageUrl,
                location);

            await _dinnerRepository.AddAsync(dinner);

            return dinner;
        }
    }
}

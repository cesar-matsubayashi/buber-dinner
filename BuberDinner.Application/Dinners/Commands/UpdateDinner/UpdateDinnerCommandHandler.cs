using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner;
using BuberDinner.Domain.Dinner.Entities;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Dinners.Commands.UpdateDinner
{
    public class UpdateDinnerCommandHandler
        : IRequestHandler<UpdateDinnerCommand, ErrorOr<Dinner>>
    {
        private readonly IDinnerRepository _dinnerRepository;

        public UpdateDinnerCommandHandler(IDinnerRepository dinnerRepository)
        {
            _dinnerRepository = dinnerRepository;
        }

        public async Task<ErrorOr<Dinner>> Handle(
            UpdateDinnerCommand request, 
            CancellationToken cancellationToken)
        {
            var dinner = await _dinnerRepository.GetAsync(request.Id);

            if (dinner is null)
            {
                return Errors.Dinner.NotFound;
            }

            var price = Price.Create(
                request.Price.Amount,
                request.Price.Currency);

            var location = Location.Create(
                request.Location.Name,
                request.Location.Address,
                request.Location.Latitude,
                request.Location.Longitude);

            dinner.Update(
                request.Name,
                request.Description,
                request.StartDateTime,
                request.EndDateTime,
                request.StartedDateTime,
                request.EndedDateTime,
                request.Status,
                request.IsPublic,
                request.MaxGuests,
                price,
                request.MenuId,
                request.ImageUrl,
                location);

            await _dinnerRepository.UpdateAsync(dinner);

            return dinner;

        }
    }
}

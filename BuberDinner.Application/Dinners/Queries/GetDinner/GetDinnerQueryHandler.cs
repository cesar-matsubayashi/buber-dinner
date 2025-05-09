using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Dinner;
using BuberDinner.Domain.Guest.ValueObjects;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Dinners.Queries.GetDinner
{
    public class GetDinnerQueryHandler 
        : IRequestHandler<GetDinnerQuery, ErrorOr<Dinner>>
    {
        private readonly IDinnerRepository _dinnerRespository;

        public GetDinnerQueryHandler(IDinnerRepository dinnerRespository)
        {
            _dinnerRespository = dinnerRespository;
        }

        public async Task<ErrorOr<Dinner>> Handle(
            GetDinnerQuery request, 
            CancellationToken cancellationToken)
        {
            var dinner = await _dinnerRespository.GetAsync(request.Id);

            if (dinner is null)
            {
                return Errors.Dinner.NotFound;
            }

            return dinner;
        }
    }
}

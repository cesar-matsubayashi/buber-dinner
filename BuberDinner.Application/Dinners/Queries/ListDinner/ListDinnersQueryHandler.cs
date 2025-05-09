using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Dinner;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Dinners.Queries.ListDinner
{
    public class ListDinnersQueryHandler
        : IRequestHandler<ListDinnersQuery, ErrorOr<List<Dinner>>>
    {
        private readonly IDinnerRepository _dinnerRepository;

        public ListDinnersQueryHandler(IDinnerRepository dinnerRepository)
        {
            _dinnerRepository = dinnerRepository;
        }

        public async Task<ErrorOr<List<Dinner>>> Handle(
            ListDinnersQuery request, 
            CancellationToken cancellationToken)
        {
            var dinners = await _dinnerRepository.GetAllAsync();

            return dinners;
        }
    }
}

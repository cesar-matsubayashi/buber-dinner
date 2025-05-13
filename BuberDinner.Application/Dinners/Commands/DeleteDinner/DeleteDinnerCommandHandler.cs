using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Dinners.Commands.DeleteDinner
{
    public class DeleteDinnerCommandHandler : IRequestHandler<DeleteDinnerCommand, ErrorOr<Deleted>>
    {
        private readonly IDinnerRepository _dinnerRepository;

        public DeleteDinnerCommandHandler(IDinnerRepository dinnerRepository)
        {
            _dinnerRepository = dinnerRepository;
        }

        public async Task<ErrorOr<Deleted>> Handle(
            DeleteDinnerCommand request, 
            CancellationToken cancellationToken)
        {
            var dinner = await _dinnerRepository.GetAsync(request.Id);

            if (dinner is null)
            {
                return Errors.Dinner.NotFound;
            }

            await _dinnerRepository.DeleteAsync(dinner);

            return new Deleted();
        }
    }
}

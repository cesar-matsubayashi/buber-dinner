using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.MenuReviews.Commands.DeleteMenuReview
{
    public class DeleteMenuReviewCommandHandler
        : IRequestHandler<DeleteMenuReviewCommand, ErrorOr<Deleted>>
    {
        private readonly IMenuReviewRepository _menuReviewRepository;

        public DeleteMenuReviewCommandHandler(IMenuReviewRepository menuReviewRepository)
        {
            _menuReviewRepository = menuReviewRepository;
        }

        public async Task<ErrorOr<Deleted>> Handle(
            DeleteMenuReviewCommand request, 
            CancellationToken cancellationToken)
        {
            var menuReview = await _menuReviewRepository.GetAsync(request.Id);

            if (menuReview is null)
            {
                return Errors.MenuReview.NotFound;
            }

            await _menuReviewRepository.DeleteAsync(menuReview);

            return new Deleted();
        }
    }
}

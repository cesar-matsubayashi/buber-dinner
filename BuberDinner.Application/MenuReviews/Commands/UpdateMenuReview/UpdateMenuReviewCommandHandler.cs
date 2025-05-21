using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.MenuReview;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.MenuReviews.Commands.UpdateMenuReview
{
    public class UpdateMenuReviewCommandHandler
        : IRequestHandler<UpdateMenuReviewCommand, ErrorOr<MenuReview>>
    {
        private readonly IMenuReviewRepository _menuReviewRepository;

        public UpdateMenuReviewCommandHandler(IMenuReviewRepository menuReviewRepository)
        {
            _menuReviewRepository = menuReviewRepository;
        }

        public async Task<ErrorOr<MenuReview>> Handle(
            UpdateMenuReviewCommand request, 
            CancellationToken cancellationToken)
        {
            var menuReview = await _menuReviewRepository.GetAsync(request.Id);

            if (menuReview is null)
            {
                return Errors.MenuReview.NotFound;
            }

            menuReview.Update(
                request.Rating,
                request.Comment);

            await _menuReviewRepository.UpdateAsync(menuReview);

            return menuReview;
        }
    }
}

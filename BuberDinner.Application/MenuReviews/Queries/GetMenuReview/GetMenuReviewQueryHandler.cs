using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.MenuReview;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.MenuReviews.Queries.GetMenuReview
{
    public class GetMenuReviewQueryHandler
        : IRequestHandler<GetMenuReviewQuery, ErrorOr<MenuReview>>
    {
        private readonly IMenuReviewRepository _menuReviewRepository;

        public GetMenuReviewQueryHandler(IMenuReviewRepository menuReviewRepository)
        {
            _menuReviewRepository = menuReviewRepository;
        }

        public async Task<ErrorOr<MenuReview>> Handle(
            GetMenuReviewQuery request, 
            CancellationToken cancellationToken)
        {
            var menuReview = await _menuReviewRepository.GetAsync(request.Id);

            if (menuReview is null)
            {
                return Errors.MenuReview.NotFound;
            }

            return menuReview;
        }
    }
}

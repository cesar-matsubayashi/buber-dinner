using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.MenuReview;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.MenuReviews.Queries.ListMenuReviewsByGuestId
{
    public class ListMenuReviewsByGuestIdQueryHandler
        : IRequestHandler<ListMenuReviewsByGuestIdQuery, ErrorOr<List<MenuReview>>>
    {
        private readonly IMenuReviewRepository _menuReviewRepository;

        public ListMenuReviewsByGuestIdQueryHandler(IMenuReviewRepository menuReviewRepository)
        {
            _menuReviewRepository = menuReviewRepository;
        }

        public async Task<ErrorOr<List<MenuReview>>> Handle(
            ListMenuReviewsByGuestIdQuery request, 
            CancellationToken cancellationToken)
        {
            var menuReviews = await _menuReviewRepository.GetAllByGuestIdAsync(request.GuestId);

            return menuReviews;
        }
    }
}

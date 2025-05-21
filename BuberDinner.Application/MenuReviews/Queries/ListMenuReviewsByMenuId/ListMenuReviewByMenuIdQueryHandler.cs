using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.MenuReview;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.MenuReviews.Queries.ListMenuReviewsByMenuId
{
    public class ListMenuReviewsByMenuIdQueryHandler
        : IRequestHandler<ListMenuReviewsByMenuIdQuery, ErrorOr<List<MenuReview>>>
    {
        private readonly IMenuReviewRepository _menuReviewRepository;

        public ListMenuReviewsByMenuIdQueryHandler(IMenuReviewRepository menuReviewRepository)
        {
            _menuReviewRepository = menuReviewRepository;
        }

        public async Task<ErrorOr<List<MenuReview>>> Handle(
            ListMenuReviewsByMenuIdQuery request, 
            CancellationToken cancellationToken)
        {
            var menuReviews = await _menuReviewRepository.GetAllByMenuIdAsync(request.MenuId);

            return menuReviews;
        }
    }
}

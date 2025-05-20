using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.MenuReview;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.MenuReviews.Commands.CreateMenuReview
{
    public class CreateMenuReviewCommandHandler
        : IRequestHandler<CreateMenuReviewCommand, ErrorOr<MenuReview>>
    {
        private readonly IMenuReviewRepository _menuReviewRepository;

        public CreateMenuReviewCommandHandler(IMenuReviewRepository menuReviewRepository)
        {
            _menuReviewRepository = menuReviewRepository;
        }

        public async Task<ErrorOr<MenuReview>> Handle(
            CreateMenuReviewCommand request, 
            CancellationToken cancellationToken)
        {
            var menuReview = MenuReview.Create(
                request.Rating,
                request.Comment,
                request.HostId,
                request.MenuId,
                request.GuestId,
                request.DinnerId);

            await _menuReviewRepository.AddAsync(menuReview);

            return menuReview;
        }
    }
}

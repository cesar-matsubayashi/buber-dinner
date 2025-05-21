using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.MenuReview;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.MenuReviews.Queries.ListMenuReviewsByGuestId
{
    public record ListMenuReviewsByGuestIdQuery(
        GuestId GuestId) : IRequest<ErrorOr<List<MenuReview>>>; 
}

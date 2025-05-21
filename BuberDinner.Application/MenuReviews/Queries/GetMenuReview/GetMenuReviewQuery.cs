using BuberDinner.Domain.MenuReview;
using BuberDinner.Domain.MenuReview.ValueObjects;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.MenuReviews.Queries.GetMenuReview
{
    public record GetMenuReviewQuery(
        MenuReviewId Id) : IRequest<ErrorOr<MenuReview>>;
}

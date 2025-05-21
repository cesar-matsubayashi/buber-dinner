using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.MenuReview;
using BuberDinner.Domain.MenuReview.ValueObjects;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.MenuReviews.Commands.UpdateMenuReview
{
    public record UpdateMenuReviewCommand(
        MenuReviewId Id,
        Rating Rating,
        string Comment) : IRequest<ErrorOr<MenuReview>>;
}

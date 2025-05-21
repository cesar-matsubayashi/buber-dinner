using BuberDinner.Domain.MenuReview.ValueObjects;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.MenuReviews.Commands.DeleteMenuReview
{
    public record DeleteMenuReviewCommand(
        MenuReviewId Id) : IRequest<ErrorOr<Deleted>>;
}

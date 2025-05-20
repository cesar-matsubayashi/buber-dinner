using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.MenuReviews.Commands.CreateMenuReview
{
    public record CreateMenuReviewCommand(
        Rating Rating,
        string Comment,
        GuestId GuestId,
        DinnerId DinnerId,
        HostId HostId,
        MenuId MenuId) : IRequest<ErrorOr<MenuReview>>;
}

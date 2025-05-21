using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.MenuReviews.Queries.ListMenuReviewsByMenuId
{
    public record ListMenuReviewsByMenuIdQuery(
        MenuId MenuId) : IRequest<ErrorOr<List<MenuReview>>>; 
}

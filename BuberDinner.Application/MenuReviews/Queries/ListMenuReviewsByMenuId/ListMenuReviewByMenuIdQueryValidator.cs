using FluentValidation;

namespace BuberDinner.Application.MenuReviews.Queries.ListMenuReviewsByMenuId
{
    public class ListMenuReviewsByMenuIdQueryValidator
        : AbstractValidator<ListMenuReviewsByMenuIdQuery>
    {
        public ListMenuReviewsByMenuIdQueryValidator()
        {
            RuleFor(m => m.MenuId).NotEmpty();
        }
    }
}

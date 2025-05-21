using FluentValidation;

namespace BuberDinner.Application.MenuReviews.Queries.ListMenuReviewsByGuestId
{
    public class ListMenuReviewsByGuestIdQueryValidator
        : AbstractValidator<ListMenuReviewsByGuestIdQuery>
    {
        public ListMenuReviewsByGuestIdQueryValidator()
        {
            RuleFor(m => m.GuestId).NotEmpty();
        }
    }
}

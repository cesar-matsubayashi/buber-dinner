using FluentValidation;

namespace BuberDinner.Application.MenuReviews.Queries.GetMenuReview
{
    public class GetMenuReviewQueryValidator : AbstractValidator<GetMenuReviewQuery>
    {
        public GetMenuReviewQueryValidator()
        {
            RuleFor(m => m.Id).NotEmpty();
        }
    }
}

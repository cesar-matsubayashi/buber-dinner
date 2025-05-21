using FluentValidation;

namespace BuberDinner.Application.MenuReviews.Commands.UpdateMenuReview
{
    public class UpdateMenuReviewCommandValidator : AbstractValidator<UpdateMenuReviewCommand>
    {
        public UpdateMenuReviewCommandValidator()
        {
            RuleFor(m => m.Id).NotEmpty();
        }
    }
}

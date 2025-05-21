using FluentValidation;

namespace BuberDinner.Application.MenuReviews.Commands.DeleteMenuReview
{
    public class DeleteMenuReviewCommandValidator : AbstractValidator<DeleteMenuReviewCommand>
    {
        public DeleteMenuReviewCommandValidator()
        {
            RuleFor(m => m.Id).NotEmpty();
        }
    }
}

using FluentValidation;

namespace BuberDinner.Application.MenuReviews.Commands.CreateMenuReview
{
    public class CreateMenuReviewCommandValidator : AbstractValidator<CreateMenuReviewCommand>
    {
        public CreateMenuReviewCommandValidator()
        {
            RuleFor(m => m.Rating).NotEmpty();
            RuleFor(m => m.Comment).NotEmpty();
            RuleFor(m => m.HostId).NotEmpty();
            RuleFor(m => m.MenuId).NotEmpty();
            RuleFor(m => m.GuestId).NotEmpty();
            RuleFor(m => m.DinnerId).NotEmpty();
        }
    }
}

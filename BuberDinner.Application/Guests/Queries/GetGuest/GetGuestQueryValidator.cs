using FluentValidation;

namespace BuberDinner.Application.Guests.Queries.GetGuest
{
    public class GetGuestQueryValidator : AbstractValidator<GetGuestQuery>
    {
        public GetGuestQueryValidator()
        {
            RuleFor(g => g.Id).NotEmpty();
        }
    }
}

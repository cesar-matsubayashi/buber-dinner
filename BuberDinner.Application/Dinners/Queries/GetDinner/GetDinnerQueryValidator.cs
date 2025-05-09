using FluentValidation;

namespace BuberDinner.Application.Dinners.Queries.GetDinner
{
    public class GetDinnerQueryValidator : AbstractValidator<GetDinnerQuery>
    {
        public GetDinnerQueryValidator()
        {
            RuleFor(d => d.Id).NotEmpty();
        }
    }
}

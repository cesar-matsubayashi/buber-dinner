using FluentValidation;

namespace BuberDinner.Application.Hosts.Queries.GetHost
{
    public class GetHostQueryValidator : AbstractValidator<GetHostQuery>
    {
        public GetHostQueryValidator()
        {
            RuleFor(h => h.Id).NotEmpty();
        }
    }
}

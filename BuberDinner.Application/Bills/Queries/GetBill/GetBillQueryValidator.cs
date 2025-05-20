using FluentValidation;

namespace BuberDinner.Application.Bills.Queries.GetBill
{
    public class GetBillQueryValidator : AbstractValidator<GetBillQuery>
    {
        public GetBillQueryValidator()
        {
            RuleFor(b => b.Id).NotEmpty();
        }
    }
}

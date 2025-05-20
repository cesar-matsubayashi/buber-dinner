using FluentValidation;

namespace BuberDinner.Application.UnitTests.Bills.Queries.GetBillsByGuestId
{
    public class ListBillsByGuestIdQueryValidator : AbstractValidator<ListBillsByGuestIdQuery>
    {
        public ListBillsByGuestIdQueryValidator()
        {
            RuleFor(b => b.GuestId).NotEmpty();
        }
    }
}

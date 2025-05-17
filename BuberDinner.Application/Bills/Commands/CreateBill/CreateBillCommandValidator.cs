using FluentValidation;

namespace BuberDinner.Application.Bills.Commands.CreateBill
{
    public class CreateBillCommandValidator : AbstractValidator<CreateBillCommand>
    {
        public CreateBillCommandValidator()
        {
            RuleFor(b => b.DinnerId).NotEmpty();
            RuleFor(b => b.GuestId).NotEmpty();
            RuleFor(b => b.HostId).NotEmpty();
            RuleFor(b => b.Price).NotEmpty();
        }
    }
}

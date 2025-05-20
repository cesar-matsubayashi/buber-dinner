using FluentValidation;

namespace BuberDinner.Application.Bills.Commands.DeleteBill
{
    public class DeleteBillCommandValidator : AbstractValidator<DeleteBillCommand>
    {
        public DeleteBillCommandValidator()
        {
            RuleFor(b => b.Id).NotEmpty();
        }
    }
}

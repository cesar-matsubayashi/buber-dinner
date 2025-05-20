using FluentValidation;

namespace BuberDinner.Application.Bills.Commands.UpdateBill
{
    public class UpdateBillCommandValidator : AbstractValidator<UpdateBillCommand>
    {
        public UpdateBillCommandValidator()
        {
            RuleFor(b => b.Id).NotEmpty();
            RuleFor(b => b.Price).NotEmpty()
                .SetValidator(new UpdatePriceCommandValidator());
        }

        public class UpdatePriceCommandValidator : AbstractValidator<UpdatePriceCommand>
        {
            public UpdatePriceCommandValidator()
            {
                RuleFor(p => p.Amount).NotEmpty();
                RuleFor(p => p.Currency).NotEmpty();
            }
        }
    }
}
